using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengePuck : MonoBehaviour
{
    public Fireball FlamingBall;
    public Tornado Fling;
    public bool WasGoal;
    private Rigidbody2D rb;
    public float MaxSpeed;
    public bool gotHit;
    public ChallengeUIScript uiManager;

    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
        gotHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gotHit == false)
        {
            if (rb.position.y > 6)
            {
                ResetPosition();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AiGoal")
        {
            WasGoal = true;
            audioManager.PlayGoal();
            uiManager.ShowRestartCanvas();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.PlayPuckCollision();
        if(collision.gameObject.tag == "PlayerRed")
        {
            gotHit = true;
            StartCoroutine(GoalTimer());
        }

    }

    private void FixedPudate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }
    public void ResetPosition()
    {
        rb.position = new Vector2(5, 0);
    }

    IEnumerator GoalTimer()
    {
        yield return new WaitForSeconds(5);
        if (gotHit == true)
        {
            uiManager.ShowRestartCanvas();
        }
    }
}
