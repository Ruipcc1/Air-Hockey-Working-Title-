using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector2 pos;
    float side;
    public Rigidbody2D player;
    public Vector2 targetPosition;
    public float MaxMovementSpeed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Throw());
    }

    void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
                        MaxMovementSpeed * Time.fixedDeltaTime));
    }

    // Update is called once per frame
    IEnumerator Throw()
    {
        yield return new WaitForSeconds(5);
        side = Random.Range(0,3);
        if(side == 0)
        {
            x = Random.Range(-12, 12);
            y = -9;
            pos = new Vector2(x, y);
            transform.position = pos;
            targetPosition = new Vector2(player.position.x, player.position.y);
            StartCoroutine(Throw());
        }
        else if(side == 1)
        {
            x = 14;
            y = Random.Range(-9, 9);
            pos = new Vector2(x, y);
            transform.position = pos;
            targetPosition = new Vector2(player.position.x, player.position.y);
            StartCoroutine(Throw());
        }
        else if (side == 2)
        {
            x = -14;
            y = Random.Range(-9, 9);
            pos = new Vector2(x, y);
            transform.position = pos;
            targetPosition = new Vector2(player.position.x, player.position.y);
            StartCoroutine(Throw());
        }
        else if (side == 3)
        {
            x = Random.Range(-12, 12);
            y = 9;
            pos = new Vector2(x, y);
            transform.position = pos;
            targetPosition = new Vector2(player.position.x, player.position.y);
            StartCoroutine(Throw());
        }
    }
}
