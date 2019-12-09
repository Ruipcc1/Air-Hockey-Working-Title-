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
        
    }
    #region PresentMap
    public void RightArrow()
    {
        if (i == 4)
        {
            CurrentMap = Maps[i];
            CurrentMap.SetActive(false);
            i = 0;
            CurrentMap = Maps[i];
            CurrentMap.SetActive(true);
        }
        else
        {
            CurrentMap = Maps[i];
            CurrentMap.SetActive(false);
            i++;
            CurrentMap = Maps[i];
            CurrentMap.SetActive(true);
        }

    }

    public void LeftArrow()
    {
        if (i == 0)
        {
            CurrentMap = Maps[i];
            CurrentMap.SetActive(false);
            i = 4;
            CurrentMap = Maps[i];
            CurrentMap.SetActive(true);
        }
        else
        {
            CurrentMap = Maps[i];
            CurrentMap.SetActive(false);
            i--;
            CurrentMap = Maps[i];
            CurrentMap.SetActive(true);
        }
    }
    #endregion
    
}

