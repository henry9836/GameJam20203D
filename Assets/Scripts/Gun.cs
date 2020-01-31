using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Fire1") == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "meteor")
                {
                    Debug.Log("shot meteor");
                    hit.transform.gameObject.GetComponent<meteor>().isshot();
                }
                else if (hit.transform.gameObject.tag == "mineableWood" || hit.transform.gameObject.tag == "mineableStone")
                { 
                    this.GetComponentInParent<Inventory>().UpdateInv(hit.transform.GetComponent<mineable>().selected, 1);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
