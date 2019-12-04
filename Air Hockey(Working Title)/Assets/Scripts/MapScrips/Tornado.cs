using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public Vector2 targetPosition;
    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    float x;
    float y;
    public bool Flung;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Flung = false;
        MaxMovementSpeed = 30;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Flung)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
                            MaxMovementSpeed * Time.fixedDeltaTime));
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Tornado")
        {
            x = Random.Range(-9, 9);
            y = Random.Range(-4, 4);
            targetPosition = new Vector2(x, y);
            Flung = true;
            StartCoroutine(Windy());
        }
        if (other.gameObject.tag == "PlayerBlue")
        {
            Flung = false;
        }
        if (other.gameObject.tag == "Enemy")
        {
            Flung = false;
        }
        if (other.gameObject.tag == "PlayerRed")
        {
            Flung = false;
        }
    }

    IEnumerator Windy()
    {
        yield return new WaitForSeconds(1);
        Flung = false;
    }
}
