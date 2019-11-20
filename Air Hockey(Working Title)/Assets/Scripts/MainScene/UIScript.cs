using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LoseTxt;

    [Header("Other")]
    public AudioManager audioManager;

    public ScoreScript scoreScript;

    public PuckScript puckScript;
    public PlayerMovement playerMovement;
    public AIScript aiScript;

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
        }
        else
        {
            audioManager.PlayWonGame();
            WinTxt.SetActive(true);
            LoseTxt.SetActive(false);
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
}