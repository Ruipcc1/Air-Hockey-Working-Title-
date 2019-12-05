using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapselector : MonoBehaviour
{
    public GameObject[] Maps;
    GameObject playingMap;
    // Start is called before the first frame update
    void Start()
    {
        switch (GameValues.PresentMap)
        {
            case GameValues.SelectedMap.Basic:
                playingMap = Maps[0];
                Instantiate(playingMap, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case GameValues.SelectedMap.Earth:
                playingMap = Maps[1];
                Instantiate(playingMap, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case GameValues.SelectedMap.Wind:
                playingMap = Maps[2];
                Instantiate(playingMap, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case GameValues.SelectedMap.Ice:
                playingMap = Maps[3];
                Instantiate(playingMap, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case GameValues.SelectedMap.Fire:
                playingMap = Maps[4];
                Instantiate(playingMap, new Vector3(0, 0, 0), Quaternion.identity);
                break;
        }
    }
}
