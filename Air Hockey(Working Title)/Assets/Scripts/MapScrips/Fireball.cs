using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector2 targetPosition;
    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    private float PitN;
    public bool FlameBall;
    private Vector2 dest;
    public GameObject Fire1;
    public GameObject Fire2;
    public GameObject Fire3;
    public GameObject Fire4;
    public GameObject Flames;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(FirePit());
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

    IEnumerator FirePit()
    {
        yield return new WaitForSeconds(5);
        PitN = Random.Range(0, 3);
        if (PitN == 0)
        {
            Fire1.transform.gameObject.SetActive(true);
            Fire2.transform.gameObject.SetActive(false);
            Fire3.transform.gameObject.SetActive(false);
            Fire4.transform.gameObject.SetActive(false);
            StartCoroutine(FirePit());
        }
        else if (PitN == 1)
        {
            Fire1.transform.gameObject.SetActive(false);
            Fire2.transform.gameObject.SetActive(true);
            Fire3.transform.gameObject.SetActive(false);
            Fire4.transform.gameObject.SetActive(false);
            targetPosition = dest;
            StartCoroutine(FirePit());
        }
        else if (PitN == 2)
        {
            Fire1.transform.gameObject.SetActive(false);
            Fire2.transform.gameObject.SetActive(false);
            Fire3.transform.gameObject.SetActive(true);
            Fire4.transform.gameObject.SetActive(false);
            targetPosition = dest;
            StartCoroutine(FirePit());
        }
        else if (PitN == 3)
        {
            Fire1.transform.gameObject.SetActive(false);
            Fire2.transform.gameObject.SetActive(false);
            Fire3.transform.gameObject.SetActive(false);
            Fire4.transform.gameObject.SetActive(true);
            targetPosition = dest;
            StartCoroutine(FirePit());
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
