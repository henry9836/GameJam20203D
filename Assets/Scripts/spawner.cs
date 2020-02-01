using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public LayerMask spawnerlayer;
    public GameObject meteor;
    public float timer = 0.0f;
    public float delay = 2.0f;
    public float rest = 10.0f;
    public bool resting = true;

    public int toSpawn = 0;
    public bool once = true;
    public int round = 0;
    public float stage1time;
    public float stage2time;
    public int stage1;
    public int stage2;
    public float stage1timer = 0.0f;
    public float stage2timer = 0.0f;
    public int haveSpawn;
    private float remainingSpawn = 0;





    void Update()
    {
        timer += Time.deltaTime;
        if (resting == true)
        {
            if (timer >= rest)
            {
                resting = false;
                timer = 0.0f;
            }
        }
        else
        {
            if (once == true)
            {
                once = false;
                round += 1;
                if (round <= 9)
                {
                    int[] zombs = new int[10] { 0, 6, 8, 13, 18, 24, 26, 27, 28, 29 };
                    toSpawn = zombs[round];
                }
                if (round >= 10)
                {
                    toSpawn = Mathf.FloorToInt(24 + ((3 * ((round / 5) * (round * 0.15f)))));
                }

                //halfs amount(balancing)
                toSpawn = Mathf.FloorToInt(toSpawn / 2);
                //--


                stage1time = (0.05f * (float)Mathf.Pow(round, 2) + 10f) / 2.0f;
                stage2time = (0.05f * (float)Mathf.Pow(round, 2) + 10f);

                stage1 = Mathf.CeilToInt(0.75f * toSpawn);
                stage2 = (toSpawn - stage1) + 1;
            }

            if (timer <= stage1time)
            {
                stage1timer += Time.deltaTime;
                float ShouldHaveSpawned = Mathf.CeilToInt((stage1timer / stage1time) * stage1);
                remainingSpawn = ShouldHaveSpawned - haveSpawn - 1;
                for (int i = 0; i < remainingSpawn; i++)
                {
                    StartCoroutine(pickpos());
                }

            }
            else if (timer <= stage2time)
            {
                stage2timer += Time.deltaTime;
                float ShouldHaveSpawned = Mathf.CeilToInt((stage2timer / (stage2time - stage1time)) * stage2);
                remainingSpawn = ShouldHaveSpawned - (haveSpawn - stage1) - 1;
                for (int i = 0; i < remainingSpawn; i++)
                {
                    StartCoroutine(pickpos());
                }
            }
            else 
            {
                resting = true;
                timer = 0.0f;
                round += 1;
                stage1timer = 0.0f;
                stage2timer = 0.0f;
                haveSpawn = 0;
                once = true;
            }

        }
    }


    public IEnumerator pickpos()
    {
        haveSpawn += 1;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(0.1f, 1.0f))), out hit, Mathf.Infinity, spawnerlayer))
        {
            Instantiate(meteor, hit.point, transform.rotation);
        }
        yield return null;
    }

    public IEnumerator pickposstar()
    {
        haveSpawn += 1;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f))), out hit, Mathf.Infinity, spawnerlayer))
        {
            //Instantiate(meteor, hit.point, transform.rotation); insert star prefab here
        }
        yield return null;
    }

}
