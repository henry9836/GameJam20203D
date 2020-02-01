using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinkleStar : MonoBehaviour
{

    public Vector2 timeThreshold = new Vector2(1.0f, 10.0f);
    public GameObject spawnerSphere;
    public GameObject starPrefab;
    private void Start()
    {
        StartCoroutine(SpawnDelay());   
    }

    IEnumerator SpawnDelay()
    {
        while (true)
        {
            StartCoroutine(spawnerSphere.GetComponent<spawner>().pickposstar(starPrefab));
            yield return new WaitForSeconds(Random.Range(timeThreshold.x, timeThreshold.y));
        }
    }
}
