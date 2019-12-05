using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillars : MonoBehaviour
{
    private float PitN;

    public GameObject[] Fires;
    int i;
    GameObject Fire;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        StartCoroutine(FirePit());
    }

    // Update is called once per frame
    IEnumerator FirePit()
    {
        yield return new WaitForSeconds(5);
        i = Random.Range(0, 4);
        if (i == 0)
        {
            foreach(GameObject fire in Fires)
            {
                fire.SetActive(false);
            }
            Fire = Fires[i];
            Fire.SetActive(true);
            StartCoroutine(FirePit());
        }
        else if (i == 1)
        {
            foreach (GameObject fire in Fires)
            {
                fire.SetActive(false);
            }
            Fire = Fires[i];
            Fire.SetActive(true);
            StartCoroutine(FirePit());
        }
        else if (i == 2)
        {
            foreach (GameObject fire in Fires)
            {
                fire.SetActive(false);
            }
            Fire = Fires[i];
            Fire.SetActive(true);
            StartCoroutine(FirePit());
        }
        else if (i == 3)
        {
            foreach (GameObject fire in Fires)
            {
                fire.SetActive(false);
            }
            Fire = Fires[i];
            Fire.SetActive(true);
            StartCoroutine(FirePit());
        }
    }
}
