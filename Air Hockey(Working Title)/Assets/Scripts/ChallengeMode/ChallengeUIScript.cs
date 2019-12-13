using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeUIScript : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LoseTxt;
    public GameObject NextLevelButton;

    [Header("Levels")]
    public GameObject[] Levels;
    GameObject playingLevel;
    public int i;
    GameObject currentLevel;

    [Header("Other")]
    public AudioManager audioManager;

    public ChallengePuck puckScript;
    public PlayerMovement playerMovement;

    public bool Lost;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        playingLevel = Levels[i];
        currentLevel = Instantiate(playingLevel, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void ShowRestartCanvas()
    {
        Time.timeScale = 0;

        CanvasRestart.SetActive(true);

        if (puckScript.WasGoal == false)
        {
            audioManager.PlayLostGame();
            WinTxt.SetActive(false);
            LoseTxt.SetActive(true);
            NextLevelButton.SetActive(false);
        }
        else if (puckScript.WasGoal == true)
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
                audioManager.PlayWonGame();
                WinTxt.SetActive(true);
                LoseTxt.SetActive(false);
                NextLevelButton.SetActive(false);
            }
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        CanvasRestart.SetActive(false);

        puckScript.ResetPosition();
        playerMovement.ResetPosition();
        puckScript.WasGoal = false;
        puckScript.gotHit = false;
    }
    public void StorySelector()
    {
        SceneManager.LoadScene(10);
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        CanvasRestart.SetActive(false);

        puckScript.ResetPosition();
        playerMovement.ResetPosition();

        puckScript.WasGoal = false;
        puckScript.gotHit = false;
        

        Destroy(currentLevel);
        i++;
        playingLevel = Levels[i];
        currentLevel = Instantiate(playingLevel, new Vector3(0, 0, 0), Quaternion.identity);
        
    }
}
