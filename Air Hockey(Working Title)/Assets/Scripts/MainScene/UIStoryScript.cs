using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIStoryScript : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

    [Header("StoryMaps")]
    public GameObject[] Maps;
    GameObject playingMap;
    public int i;
    GameObject currentMap;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LoseTxt;
    public GameObject NextLevelButton;

    [Header("Other")]
    public AudioManager audioManager;

    public StoryScoreScript scoreScript;

    public StoryPuckScript puckScript;
    public PlayerMovement playerMovement;
    public AIScript aiScript;


    void Start()
    {
        Time.timeScale = 1;
        i = 0;
        playingMap = Maps[i];
        currentMap = Instantiate(playingMap, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void ShowRestartCanvas(bool didAiWin)
    {
        Time.timeScale = 0;

        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if (didAiWin)
        {
            audioManager.PlayLostGame();
            WinTxt.SetActive(false);
            LoseTxt.SetActive(true);
            NextLevelButton.SetActive(false);
        }
        else
        {
            if (i < 4)
            {
                audioManager.PlayWonGame();
                WinTxt.SetActive(true);
                LoseTxt.SetActive(false);
                NextLevelButton.SetActive(true);
            }
            else if (i == 4)
            {
                SceneManager.LoadScene(9);
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);

        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovement.ResetPosition();
        aiScript.ResetPosition();
    }
    public void ShowMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void AiSelector()
    {
        SceneManager.LoadScene("AISelection");
    }
    public void PlayvsPlayer()
    {
        SceneManager.LoadScene("LocalMultiplayer");
    }
    public void NextLevel()
    {
        Time.timeScale = 1;

        CanvasGame.SetActive(true);
        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovement.ResetPosition();
        aiScript.ResetPosition();

        Destroy(currentMap);
        i++;
        playingMap = Maps[i];
        currentMap = Instantiate(playingMap, new Vector3(0, 0, 0), Quaternion.identity);
        CanvasRestart.SetActive(false);

        
    }
    public void StorySelector()
    {
        SceneManager.LoadScene(7);
    }
}
