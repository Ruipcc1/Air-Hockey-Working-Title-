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
            GameValues.PresentMap = GameValues.SelectedMap.Basic;
        }
        else if (whichMap.i == 1)
        {
            GameValues.PresentMap = GameValues.SelectedMap.Earth;
        }
        else if (whichMap.i == 2)
        {
            GameValues.PresentMap = GameValues.SelectedMap.Wind;
        }
        else if (whichMap.i == 3)
        {
            GameValues.PresentMap = GameValues.SelectedMap.Ice;
        }
        else if (whichMap.i == 4)
        {
            GameValues.PresentMap = GameValues.SelectedMap.Fire;
        }
    }
    public void PlayvsPlayer()
    {
        SceneManager.LoadScene(2);
        if (whichMap.i == 0)
        {
            GameValues.PresentMap = GameValues.SelectedMap.Basic;
        }
        else if (whichMap.i == 1)
        {
            GameValues.PresentMap = GameValues.SelectedMap.Earth;
        }
        else if (whichMap.i == 2)
        {
            GameValues.PresentMap = GameValues.SelectedMap.Wind;
        }
        else if (whichMap.i == 3)
        {
            GameValues.PresentMap = GameValues.SelectedMap.Ice;
        }
        else if (whichMap.i == 4)
        {
            GameValues.PresentMap = GameValues.SelectedMap.Fire;
        }
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
    public void PvPSelector()
    {
        SceneManager.LoadScene(6);
    }
    public void StorySelector()
    {
        SceneManager.LoadScene(7);
    }
    public void StoryMode()
    {
        SceneManager.LoadScene(8);
    }
    public void LevelSelector()
    {
        SceneManager.LoadScene(10);
    }
}
