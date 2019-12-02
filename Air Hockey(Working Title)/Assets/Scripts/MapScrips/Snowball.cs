using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector2 pos;
    Vector2 dest;
    float side;
    public GameObject iceR;
    public GameObject iceB;
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
            x = Random.Range(-6, 6);
            dest = new Vector2(x, 9);
            transform.position = pos;
            targetPosition = dest;
            StartCoroutine(Throw());
        }
        else if(side == 1)
        {
            x = 14;
            y = Random.Range(-9, 9);
            pos = new Vector2(x, y);
            y = Random.Range(-4, 4);
            dest = new Vector2(-14, y);
            transform.position = pos;
            targetPosition = dest;
            StartCoroutine(Throw());
        }
        else if (side == 2)
        {
            x = -14;
            y = Random.Range(-9, 9);
            pos = new Vector2(x, y);
            y = Random.Range(-4, 4);
            dest = new Vector2(14, y);
            transform.position = pos;
            targetPosition = dest;
            StartCoroutine(Throw());
        }
        else if (side == 3)
        {
            x = Random.Range(-12, 12);
            y = 9;
            pos = new Vector2(x, y);
            x = Random.Range(-6, 6);
            transform.position = pos;
            dest = new Vector2(x, -9);
            targetPosition = dest;
            StartCoroutine(Throw());
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerRed")
        {
            iceR.transform.gameObject.SetActive(true);
            GameObject.FindWithTag("PlayerRed").GetComponent<PlayerMovement>().MaxMovementSpeed = 0;
            StartCoroutine(FreezeR());
        }
        if (other.gameObject.tag == "PlayerBlue")
        {
            iceB.transform.gameObject.SetActive(true);
            GameObject.FindWithTag("PlayerBlue").GetComponent<PlayerMovement>().MaxMovementSpeed = 0;
            StartCoroutine(FreezeB());
        }
        if (other.gameObject.tag == "Enemy")
        {
            iceB.transform.gameObject.SetActive(true);
            GameObject.FindWithTag("Enemy").GetComponent<AIScript>().MaxMovementSpeed = 0;
            StartCoroutine(Freeze1());
        }
    }

    IEnumerator FreezeR()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindWithTag("PlayerRed").GetComponent<PlayerMovement>().MaxMovementSpeed = 30;
        iceR.transform.gameObject.SetActive(false);
    }

    IEnumerator FreezeB()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindWithTag("PlayerBlue").GetComponent<PlayerMovement>().MaxMovementSpeed = 30;
        iceB.transform.gameObject.SetActive(false);
    }

    IEnumerator Freeze1()
    {
        yield return new WaitForSeconds(2);
        iceB.transform.gameObject.SetActive(false);
        switch (GameValues.Difficulty)
        {
            case GameValues.Difficulties.Easy:
                GameObject.FindWithTag("Enemy").GetComponent<AIScript>().MaxMovementSpeed = 10;
                break;
            case GameValues.Difficulties.Medium:
                GameObject.FindWithTag("Enemy").GetComponent<AIScript>().MaxMovementSpeed = 15;
                break;
            case GameValues.Difficulties.Hard:
                GameObject.FindWithTag("Enemy").GetComponent<AIScript>().MaxMovementSpeed = 20;
                break;
        }
    }
}
