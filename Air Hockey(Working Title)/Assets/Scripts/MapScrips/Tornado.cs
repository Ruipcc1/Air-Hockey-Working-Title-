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
    private bool Flung;
    // Start is called before the first frame update
    void Start()
    {
        Flung = false;
    }

    // Update is called once per frame
    void Update()
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
            x = Random.Range(-12, 12);
            y = Random.Range(-4, 4);
            targetPosition = new Vector2(x, y);
            Flung = true;
            StartCoroutine(Windy());
        }
    }

    IEnumerator Windy()
    {
        yield return new WaitForSeconds(1);
        Flung = false;
    }
}
