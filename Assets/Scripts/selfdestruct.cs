using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestruct : MonoBehaviour
{

    public float killAfterSeconds = 60.0f;


    void Update()
    {
        killAfterSeconds -= Time.deltaTime;
        if (killAfterSeconds <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
