using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public GameObject[] Levels;
    GameObject Level;
    // Start is called before the first frame update
    void Start()
    {
        switch (GameValues.CurrentLevel)
        {
            case GameValues.LevelSelection.Level1:
                Level = Levels[0];
                Instantiate(Level, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case GameValues.LevelSelection.Level2:
                Level = Levels[1];
                Instantiate(Level, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case GameValues.LevelSelection.Level3:
                Level = Levels[2];
                Instantiate(Level, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case GameValues.LevelSelection.Level4:
                Level = Levels[3];
                Instantiate(Level, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case GameValues.LevelSelection.Level5:
                Level = Levels[4];
                Instantiate(Level, new Vector3(0, 0, 0), Quaternion.identity);
                break;
        }
    }
}
