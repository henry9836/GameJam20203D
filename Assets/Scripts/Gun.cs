using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("Fire1") == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "meteor")
                {
                    Debug.Log("shot meteor");
                }
                else if (hit.transform.gameObject.tag == "mineable")
                {
                    Debug.Log("mineing away, in this minecraft day SO BUTIFUL");
                }
            }
        }
    }
}
