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
}
