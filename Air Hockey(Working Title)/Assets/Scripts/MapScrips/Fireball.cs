using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector2 targetPosition;
    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    public bool FlameBall;
    public GameObject Flames;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MaxMovementSpeed = 30;
        FlameBall = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FlameBall)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
                            MaxMovementSpeed * Time.fixedDeltaTime));
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "RightFirePit")
        {
            Flames.transform.gameObject.SetActive(true);
            targetPosition = new Vector2(-11, 0);
            FlameBall = true;
        }
        if (other.gameObject.tag == "LeftFirePit")
        {
            Flames.transform.gameObject.SetActive(true);
            targetPosition = new Vector2(11, 0);
            FlameBall = true;
        }
        if (other.gameObject.tag == "PlayerBlue")
        {
            Flames.transform.gameObject.SetActive(false);
            FlameBall = false;
        }
        if (other.gameObject.tag == "Enemy")
        {
            Flames.transform.gameObject.SetActive(false);
            FlameBall = false;
        }
        if (other.gameObject.tag == "PlayerRed")
        {
            Flames.transform.gameObject.SetActive(false);
            FlameBall = false;
        }
    }
}
