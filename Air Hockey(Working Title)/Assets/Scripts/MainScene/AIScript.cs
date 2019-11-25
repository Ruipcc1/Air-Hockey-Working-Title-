using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{

    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    Vector2 startingPosition;

    public Rigidbody2D Puck;
    public Rigidbody2D AiStriker;

    public Transform PlayerBoundaryHolder;
    private Boundary playerBoundary;

    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;

    public Transform AIDefenseHolder;
    private Boundary defenseBoundary;

    private Vector2 targetPosition;

    private bool isFirstTimeInOpponentsHalf = true;
    private float offsetYFromTarget;

    public GameObject CircleCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;

        playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y,
                              PlayerBoundaryHolder.GetChild(1).position.y,
                              PlayerBoundaryHolder.GetChild(2).position.x,
                              PlayerBoundaryHolder.GetChild(3).position.x);

        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                              PuckBoundaryHolder.GetChild(1).position.y,
                              PuckBoundaryHolder.GetChild(2).position.x,
                              PuckBoundaryHolder.GetChild(3).position.x);

        switch (GameValues.Difficulty)
        {
            case GameValues.Difficulties.Easy:
                MaxMovementSpeed = 10;
                break;
            case GameValues.Difficulties.Medium:
                MaxMovementSpeed = 15;
                break;
            case GameValues.Difficulties.Hard:
                MaxMovementSpeed = 20;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (AiStriker.position.x > Puck.position.x)
        {
            CircleCollider.gameObject.SetActive(true);
        }
        else
        {
            CircleCollider.gameObject.SetActive(false);
        }

            if (!PuckScript.WasGoal)
        {
            float movementSpeed;

            if (Puck.position.x > puckBoundary.Right)
            {
                if (isFirstTimeInOpponentsHalf)
                {
                    isFirstTimeInOpponentsHalf = false;
                    offsetYFromTarget = Random.Range(-1f, 1f);
                }

                movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
                targetPosition = new Vector2(startingPosition.x, Mathf.Clamp(Puck.position.y + offsetYFromTarget, playerBoundary.Down,
                                                        playerBoundary.Up));
            }
            else
            {
                isFirstTimeInOpponentsHalf = true;

                movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left,
                                            playerBoundary.Right),
                                            Mathf.Clamp(Puck.position.y, playerBoundary.Down,
                                            playerBoundary.Up));
            }

            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
                    movementSpeed * Time.fixedDeltaTime));
        }
    }
    public void ResetPosition()
    {
        rb.position = startingPosition;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        MaxMovementSpeed = 30;

    }

    void OnTriggerEnter2D(Collision2D col) {
        print("Hello World!");
        MaxMovementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
        if (col.gameObject.tag == "Circle")
        {
            targetPosition = new Vector2(playerBoundary.Right, playerBoundary.Right);
        }
}
void OnCollisionExit2D(Collision2D col)
    {
        switch (GameValues.Difficulty)
        {
            case GameValues.Difficulties.Easy:
                MaxMovementSpeed = 10;
                break;
            case GameValues.Difficulties.Medium:
                MaxMovementSpeed = 15;
                break;
            case GameValues.Difficulties.Hard:
                MaxMovementSpeed = 20;
                break;
        }
    }
}