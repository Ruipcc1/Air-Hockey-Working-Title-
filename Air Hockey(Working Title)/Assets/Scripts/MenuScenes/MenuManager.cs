using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayLocal()
    {
        SceneManager.LoadScene(3);
    }


    public void PlayOnline()
    {
        SceneManager.LoadScene("Online");
    }
}
