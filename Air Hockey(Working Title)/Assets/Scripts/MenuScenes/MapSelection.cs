using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    public GameObject[] Maps;
    public int i;
    GameObject CurrentMap;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        CurrentMap = Maps[i];
        CurrentMap.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(i == 5){
            i = 0;
            CurrentMap = Maps[i];
            CurrentMap.SetActive(true);
        }
    }

    public void RightArrow()
    {
        CurrentMap = Maps[i];
        CurrentMap.SetActive(false);
        i++;
        CurrentMap = Maps[i];
        CurrentMap.SetActive(true);

    }

    public void LeftArrow()
    {
        CurrentMap = Maps[i];
        CurrentMap.SetActive(false);
        i--;
        CurrentMap = Maps[i];
        CurrentMap.SetActive(true);
    }
}

