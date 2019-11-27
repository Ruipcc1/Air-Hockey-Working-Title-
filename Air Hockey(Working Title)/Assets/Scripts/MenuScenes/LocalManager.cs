using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalManager : MonoBehaviour
{
    public void PlayvsAI()
    {
        SceneManager.LoadScene(4);
    }
    public void PlayvsPlayer()
    {
        SceneManager.LoadScene(2);
    }
    public void AiSelector()
    {
        SceneManager.LoadScene(5);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void Local()
    {
        SceneManager.LoadScene(3);
    }
}
