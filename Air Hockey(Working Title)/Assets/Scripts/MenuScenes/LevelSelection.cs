using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void LevelSelect1()
    {
        GameValues.CurrentLevel = GameValues.LevelSelection.Level1;
        SceneManager.LoadScene(11);
    }
    public void LevelSelect2()
    {
        GameValues.CurrentLevel = GameValues.LevelSelection.Level2;
        SceneManager.LoadScene(11);
    }
    public void LevelSelect3()
    {
        GameValues.CurrentLevel = GameValues.LevelSelection.Level3;
        SceneManager.LoadScene(11);
    }
    public void LevelSelect4()
    {
        GameValues.CurrentLevel = GameValues.LevelSelection.Level4;
        SceneManager.LoadScene(11);
    }
    public void LevelSelect5()
    {
        GameValues.CurrentLevel = GameValues.LevelSelection.Level5;
        SceneManager.LoadScene(11);
    }
}
