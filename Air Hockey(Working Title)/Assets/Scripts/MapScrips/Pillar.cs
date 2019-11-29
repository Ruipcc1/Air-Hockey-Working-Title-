using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector3 pos;
    void Start()
    {
        x = Random.Range(-9, 9);
        y = Random.Range(-4, 4);
        z = 0;
        pos = new Vector3(x, y, z);
        transform.position = pos;
        StartCoroutine(PillarMove());
    }

    IEnumerator PillarMove()
    {
        yield return new WaitForSeconds(5);
        x = Random.Range(-9, 9);
        y = Random.Range(-4, 4);
        z = 0;
        pos = new Vector3(x, y, z);
        transform.position = pos;
        StartCoroutine(PillarMove());
    }
}
