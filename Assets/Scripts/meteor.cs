using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public float size = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.localScale = new Vector3(size, size, size);
    }
}
