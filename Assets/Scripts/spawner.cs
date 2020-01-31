using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public LayerMask spawnerlayer;
    public GameObject meteor;
    public float timer = 0.0f;
    public float delay = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            StartCoroutine(pickpos());
            timer = 0.0f;
        }
    }


    public IEnumerator pickpos()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(0.1f, 1.0f))), out hit, Mathf.Infinity, spawnerlayer))
        {
            Instantiate(meteor, hit.point, transform.rotation);
        }



        yield return null;
    }

}
