using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] PuckCollision;
    public AudioClip Goal;
    public AudioClip BlueWins;
    public AudioClip RedWins;

    private AudioSource audioSource;

    private AudioClip randomPick;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuckCollision()
    {
        randomPick = PuckCollision[Random.Range(0, PuckCollision.Length)];
        audioSource.PlayOneShot(randomPick);
    }

    public void PlayGoal()
    {
        audioSource.PlayOneShot(Goal);
    }

    public void PlayLostGame()
    {
        audioSource.PlayOneShot(BlueWins);
    }

    public void PlayWonGame()
    {
        audioSource.PlayOneShot(RedWins);
    }
}
