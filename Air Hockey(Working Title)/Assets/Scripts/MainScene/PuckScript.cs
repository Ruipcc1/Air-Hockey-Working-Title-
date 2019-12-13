using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{

    public ScoreScript ScoreScriptInstance;
    public Fireball FlamingBall;
    public Tornado Fling;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;
    private Vector2 currentPosition;
    private Vector2 previousPosition;
    public bool BlueGoal;
    public float MaxSpeed;

    public AudioManager audioManager;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
        StartCoroutine(Unstuck());
    }

    private void Update()
    {
        if (rb.position.y > 6)
        {
            CenterPuck();
        }
        if (rb.position.y < -6)
        {
            CenterPuck();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                WasGoal = true;
                BlueGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck());
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.PlayPuckCollision();
    }

    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        
        if (BlueGoal)
        {
            rb.position = new Vector2(-6, 0);
            rb.velocity = new Vector2(0, 0);

            BlueGoal = false;
        }
        else
        {
            rb.position = new Vector2(6, 0);
            rb.velocity = new Vector2(0, 0);
        }
        FlamingBall.FlameBall = false;
        FlamingBall.Flames.transform.gameObject.SetActive(false);
        Fling.Flung = false;
    }

    private IEnumerator Unstuck()
    {
        previousPosition = rb.position;
        yield return new WaitForSecondsRealtime(3);
        currentPosition = rb.position;
        if (previousPosition == currentPosition)
        {
            CenterPuck();
        }
        StartCoroutine(Unstuck());
    }

    public void CenterPuck()
    {
        rb.position = new Vector2(0, 0);
    }
    private void FixedPudate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }

}
