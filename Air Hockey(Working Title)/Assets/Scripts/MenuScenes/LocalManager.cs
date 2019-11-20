using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalManager : MonoBehaviour
{
    public void PlayvsAI()
    {
        SceneManager.LoadScene("PracticeMode");
    }
    public void PlayvsPlayer()
    {
        SceneManager.LoadScene("LocalMultiplayer");
    }
    public void AiSelector()
    {
        SceneManager.LoadScene("AISelection");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
