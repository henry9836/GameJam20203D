using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunshake : MonoBehaviour
{
    public float origX;
    public float origY;
    public float origZ;

    public float timer = 0.5f;



    void Start()
    {
        origX = this.gameObject.transform.localPosition.x;
        origY = this.gameObject.transform.localPosition.y;
        origZ = this.gameObject.transform.localPosition.z;
    }

    public void shooting()
    {
        timer -= Time.deltaTime;

        if (timer < 0.0f)
        {
            timer = 0.08f;
            StartCoroutine(wigglex());
            StartCoroutine(wiggley());
            StartCoroutine(wigglez());
        }
    }

    public IEnumerator wiggley()
    {
        float rand = Random.Range(-0.01f, 0.01f);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 12.0f)
        {
            this.gameObject.transform.localPosition += new Vector3(0, rand, 0);   
            yield return null;
        }
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 12.0f)
        {
            this.gameObject.transform.localPosition -= new Vector3(0, rand, 0);
            yield return null;
        }
    }
    public IEnumerator wigglez()
    {
        float rand = Random.Range(-0.01f, 0.01f);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 12.0f)
        {
            this.gameObject.transform.localPosition += new Vector3(0, 0, rand);
            yield return null;
        }
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 12.0f)
        {
            this.gameObject.transform.localPosition -= new Vector3(0, 0, rand);
            yield return null;
        }
    }

    public IEnumerator wigglex()
    {
        float rand = Random.Range(-0.01f, 0.01f);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 12.0f)
        {
            this.gameObject.transform.localPosition += new Vector3(rand, 0, 0);
            yield return null;
        }
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 12.0f)
        {
            this.gameObject.transform.localPosition -= new Vector3(rand, 0, 0);
            yield return null;
        }
    }

}
