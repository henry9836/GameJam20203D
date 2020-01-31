using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject gunTip;
    

    void Update()
    {
        if (Input.GetButton("Fire1") == true)
        {
            gunTip.GetComponent<LineRenderer>().enabled = true;
            RaycastHit hit;
            //If we hit something
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
                        Debug.Log(hit.transform.gameObject.GetComponent<mineable>().HP);
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("GameManager").GetComponent<score>().addscore(5.0f);
                        this.GetComponentInParent<Inventory>().UpdateInv(hit.transform.GetComponent<mineable>().selected, 1);
                        Destroy(hit.transform.gameObject);
                    }
                }
                //Hit Something
                gunTip.GetComponent<LineRenderer>().SetPosition(0, gunTip.transform.position);
                gunTip.GetComponent<LineRenderer>().SetPosition(1, hit.point);
            }
            else
            {
                //Pretend To Hit Something
                gunTip.GetComponent<LineRenderer>().SetPosition(0, gunTip.transform.position);
                gunTip.GetComponent<LineRenderer>().SetPosition(1, transform.forward * 1000.0f);
            }
        }
        else
        {
            gunTip.GetComponent<LineRenderer>().enabled = false;
        }
    }
}
