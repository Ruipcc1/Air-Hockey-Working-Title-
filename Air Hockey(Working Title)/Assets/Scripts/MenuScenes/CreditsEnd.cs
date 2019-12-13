using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsEnd : MonoBehaviour
{
    public AudioClip yourReality;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(Credits());
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(yourReality);
    }

    IEnumerator Credits()
    {
        yield return new WaitForSeconds(180);
        SceneManager.LoadScene(0);
    }
}
