using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMovement : MonoBehaviour
{
    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    public float xAdd;
    public float yAdd;
    private Vector2 currentPosition;
    public Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MaxMovementSpeed = 5;
        StartCoroutine(TornMove());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
                            MaxMovementSpeed * Time.fixedDeltaTime));
        rb.rotation += 360 * Time.fixedDeltaTime;
    }

    IEnumerator TornMove()
    {
        yield return new WaitForSeconds(1);
        xAdd = Random.Range(-5, 6);
        yAdd = Random.Range(-5, 6);
        
        currentPosition = rb.position;

        currentPosition.x = currentPosition.x + xAdd;
        currentPosition.y = currentPosition.y + yAdd;

        if (currentPosition.x <= -9)
        {
            currentPosition.x = -8;
        }
        if(currentPosition.x >= 9)
        {
            currentPosition.x = 8;
        }
        if (currentPosition.y <= -4)
        {
            currentPosition.y = -4;
        }
        if (currentPosition.y >= 4)
        {
            currentPosition.y = 4;
        }
        targetPosition = new Vector2(currentPosition.x, currentPosition.y);
        StartCoroutine(TornMove());
    }
}
