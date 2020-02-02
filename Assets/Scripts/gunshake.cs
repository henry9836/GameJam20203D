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
            timer = 0.5f;
            StartCoroutine(wigglex());
            StartCoroutine(wiggley());
            StartCoroutine(wigglez());
        }
    }

    public IEnumerator wiggley()
    {
        float rand = Random.Range(-0.2f, 0.2f);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 4.0f)
        {
            this.gameObject.transform.localPosition += new Vector3(0, Mathf.Lerp(origY, origY + rand, t), 0);   
            yield return null;
        }
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 4.0f)
        {
            this.gameObject.transform.localPosition -= new Vector3(0, Mathf.Lerp(origY + rand, origY, t), 0);
            yield return null;
        }
    }
    public IEnumerator wigglez()
    {
        float rand = Random.Range(-0.2f, 0.2f);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 4.0f)
        {
            this.gameObject.transform.localPosition += new Vector3(0, 0, Mathf.Lerp(origZ, origZ + rand, t));
            yield return null;
        }
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 4.0f)
        {
            this.gameObject.transform.localPosition -= new Vector3(0, 0, Mathf.Lerp(origZ, origZ + rand, t));
            yield return null;
        }
    }

    public IEnumerator wigglex()
    {
        float rand = Random.Range(-0.2f, 0.2f);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 4.0f)
        {
            this.gameObject.transform.localPosition += new Vector3(Mathf.Lerp(origX, origX + rand, t), 0, 0);
            yield return null;
        }
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 4.0f)
        {
            this.gameObject.transform.localPosition -= new Vector3(Mathf.Lerp(origX, origX + rand, t), 0, 0);
            yield return null;
        }
    }

}
