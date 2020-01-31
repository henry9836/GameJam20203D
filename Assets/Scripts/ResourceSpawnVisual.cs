using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawnVisual : MonoBehaviour
{

    public float spawnTime = 1.0f;
    public Vector2 sizeFactorRange = new Vector2(1.3f, 2.0f);

    private Vector3 startSize;

    private void Start()
    {
        startSize = transform.localScale;
        StartCoroutine(VisualLoop());
    }

    IEnumerator VisualLoop()
    {
        float scalar = Random.Range(sizeFactorRange.x, sizeFactorRange.y);

        float i = 0.0f;
        while (i < 1.0f)
        {
            i += Time.deltaTime / spawnTime;
            transform.localScale = Vector3.Lerp(startSize, startSize * scalar, i);
            yield return null;
        }

        yield return null;
    }
}
