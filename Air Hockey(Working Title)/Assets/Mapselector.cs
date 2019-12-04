using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapselector : MonoBehaviour
{
    public MapSelection activateMap;
    public GameObject[] Maps;
    GameObject playingMap;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Maps.Length(); i++)
        {
            Maps[i].SetActive(false);
        }


        int m = PlayerPrefs.GetInt("Map");
        playingMap = Maps[m];
        playingMap.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
