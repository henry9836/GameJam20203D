using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairMechanic : MonoBehaviour
{

    public int costForPlank = 1;
    public int costForTile = 1;
    public LayerMask buildLayer;


    public AudioClip woodpickup;
    public AudioClip stonepickup;
    public AudioSource source;

    private RaycastHit hit;
    private float buildDistance = 0;
    private Inventory inv;




    private void Start()
    {
        buildDistance = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BuildVisual>().distanceThreshold;
        inv = transform.parent.GetComponent<Inventory>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, buildDistance, buildLayer))
            {
                //Check for damage so we don't fix anything that isn't visually hurt
                if (hit.collider.gameObject.transform.parent.GetComponent<distructableObjs>().HP <= hit.collider.transform.parent.gameObject.GetComponent<distructableObjs>().damagedHealthStateThreshold)
                {

                    //Fix thing
                    //Wood
                    if (hit.collider.tag == "PlankBuild")
                    {
                        //Try and use inventory
                        if (inv.UpdateInv(Inventory.ITEM.WOOD, -costForPlank))
                        {
                            //Fix Plank
                            hit.collider.gameObject.transform.parent.GetComponent<distructableObjs>().HP = 100.0f;
                            source.clip = woodpickup;
                            source.Play();
                        }
                        else
                        {
                            Debug.LogWarning("An Error Occured Updating Inv");
                        }
                    }
                    //Stone
                    else if (hit.collider.tag == "TileBuild")
                    {
                        //Try and use inventory
                        if (inv.UpdateInv(Inventory.ITEM.STONE, -costForTile))
                        {
                            //Fix tile
                            hit.collider.gameObject.transform.parent.GetComponent<distructableObjs>().HP = 100.0f;
                            source.clip = stonepickup;
                            source.Play();
                        }
                        else
                        {
                            Debug.LogWarning("An Error Occured Updating Inv");
                        }
                    }
                }

            }
        }
    }
}
