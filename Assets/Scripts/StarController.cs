using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{

    public Vector2 spawnDistanceRange = new Vector2(1, 1000);
    public Vector2 spawnSizes = new Vector2(0.5f, 10.0f);
    public float MaxExistTime = 120.0f;
    public float FadeTime = 10.0f;

    private float targetPower = 2000000.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Move away
        transform.position += -transform.forward * Random.Range(spawnDistanceRange.x, spawnDistanceRange.y);

        //Random Size
        transform.localScale *= Random.Range(spawnSizes.x, spawnSizes.y);

        //Assign Random Color
        Color color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        GetComponent<MeshRenderer>().material.SetColor("Color_9E5C6EB2", color);
        GetComponent<MeshRenderer>().material.SetFloat("Vector1_D6179077", 0.0f);

        StartCoroutine(Ignite());
    }

    IEnumerator Ignite()
    {
        for (float t = 0; t < 1.0f; t += Time.deltaTime / FadeTime)
        {
            float power = Mathf.Lerp(0.0f, targetPower, t);
            GetComponent<MeshRenderer>().material.SetFloat("Vector1_D6179077", power);
            yield return null;
        }

        yield return new WaitForSeconds(Random.Range(5.0f, MaxExistTime));

        for (float t = 0; t < 1.0f; t += Time.deltaTime / FadeTime)
        {
            float power = Mathf.Lerp(targetPower, 0.0f, t);
            GetComponent<MeshRenderer>().material.SetFloat("Vector1_D6179077", power);
            yield return null;
        }

        Destroy(gameObject);
        yield return null;
    }

}
