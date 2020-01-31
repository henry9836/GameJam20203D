using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public float spawnRadius = 10.0f;
    public int maxObjects = 15;
    public Inventory.ITEM type;
    public Vector2 minMaxSpawnTimeThreshold = new Vector2(2.0f, 15.0f);
    public List<GameObject> spawnableObjects = new List<GameObject>();
    public LayerMask groundLayer;
    public float safeSpawnCheckRadius = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnableObjects.Count == 0)
        {
            Debug.LogWarning("Spawnable count is zero on " + gameObject.name);
        }

        StartCoroutine(SpawnLoop());

    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            GameObject[] Spawnedobjs = null;
            if (type == Inventory.ITEM.WOOD)
            {
                Spawnedobjs = GameObject.FindGameObjectsWithTag("mineableWood");
            }
            else  if (type == Inventory.ITEM.STONE)
            {
                Spawnedobjs = GameObject.FindGameObjectsWithTag("mineableStone");
            }

            if (maxObjects >= Spawnedobjs.Length)
            {

                //Wait Before Spawning
                float randomWaitTime = Random.Range(minMaxSpawnTimeThreshold.x, minMaxSpawnTimeThreshold.y);
                yield return new WaitForSeconds(randomWaitTime);

                int objIndex = Random.Range(0, spawnableObjects.Count);

                //Spawn within my area
                Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(-spawnRadius, spawnRadius), transform.position.y, transform.position.z + Random.Range(-spawnRadius, spawnRadius));

                //Don't spawn inside another obj
                while (true)
                {
                    if (Physics.CheckSphere(spawnPos, safeSpawnCheckRadius, ~(groundLayer)))
                    {
                        //Hit something try again
                        Debug.LogWarning("Could not spawn object at position since obsctcle retrying...");
                        spawnPos = new Vector3(transform.position.x + Random.Range(-spawnRadius, spawnRadius), transform.position.y, transform.position.z + Random.Range(-spawnRadius, spawnRadius));
                    }
                    //Floating Ignore
                    else
                    {
                        
                    }
                    yield return null;
                }

                Instantiate(spawnableObjects[objIndex], spawnPos, Quaternion.identity);
            }
            yield return null;
        }
    }
    
}
