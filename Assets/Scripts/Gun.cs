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
                    if (hit.transform.gameObject.GetComponent<meteor>().HP > 0.0f)
                    {
                        hit.transform.gameObject.GetComponent<meteor>().HP -= 250.0f * Time.deltaTime;
                        Debug.Log(hit.transform.gameObject.GetComponent<meteor>().HP);
                    }
                    else 
                    {
                        GameObject.FindGameObjectWithTag("GameManager").GetComponent<score>().addscore(5.0f);

                        hit.transform.gameObject.GetComponent<meteor>().isshot();
                    }
                }
                else if (hit.transform.gameObject.tag == "mineableWood" || hit.transform.gameObject.tag == "mineableStone")
                {
                    if (hit.transform.gameObject.GetComponent<mineable>().HP > 0.0f)
                    {
                        hit.transform.gameObject.GetComponent<mineable>().HP -= 200.0f * Time.deltaTime;
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("GameManager").GetComponent<score>().addscore(5.0f);
                        this.GetComponentInParent<Inventory>().UpdateInv(hit.transform.GetComponent<mineable>().selected, 1);
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
    }
}
