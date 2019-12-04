using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalManager : MonoBehaviour
{
    public MapSelection whichMap;
    public void PlayvsAI()
    {
        SceneManager.LoadScene(4);
        if(whichMap.i == 0)
        {
            PlayerPrefs.SetInt("Map", 0);
        }
        else if (whichMap.i == 1)
        {
            PlayerPrefs.SetInt("Map", 1);
        }
        else if (whichMap.i == 2)
        {
            PlayerPrefs.SetInt("Map", 2);
        }
        else if (whichMap.i == 3)
        {
            PlayerPrefs.SetInt("Map", 3);
        }
        else if (whichMap.i == 4)
        {
            PlayerPrefs.SetInt("Map", 4);
        }
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
