using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildVisual : MonoBehaviour
{
    public float distanceThreshold = 10.0f;
    public Material canBuildPreview;
    public Material cannotBuildPreview;

    private GameObject[] planks;
    private GameObject[] tiles;
    private List<GameObject> repairableObjs = new List<GameObject>();
    private GameObject player;

    private void Start()
    {
        planks = GameObject.FindGameObjectsWithTag("Plank");
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        for (int i = 0; i < planks.Length; i++)
        {
            repairableObjs.Add(planks[i]);
        }

        for (int i = 0; i < tiles.Length; i++)
        {
            repairableObjs.Add(tiles[i]);
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //Change visual of planks when damaged and nearby
        for (int i = 0; i < repairableObjs.Count; i++)
        {
            //Check distance
            Debug.Log(Vector3.Distance(repairableObjs[i].transform.position, player.transform.position));

            if (Vector3.Distance(repairableObjs[i].transform.position, player.transform.position) < distanceThreshold)
            {
                //Check damage
                if (repairableObjs[i].GetComponent<distructableObjs>().amDead)
                {
                    //Override Mat
                    repairableObjs[i].GetComponent<distructableObjs>().matOverrideFlag = true;

                    bool canBuild = false;

                    if (repairableObjs[i].tag == "Plank")
                    {
                        canBuild = (player.GetComponent<Inventory>().inventory[Inventory.ITEM.WOOD] >= player.GetComponent<RepairMechanic>().costForPlank);
                    }
                    else
                    {
                        canBuild = (player.GetComponent<Inventory>().inventory[Inventory.ITEM.STONE] >= player.GetComponent<RepairMechanic>().costForTile);
                    }

                    //Override Mat According To Inv
                    if (canBuild)
                    {
                        repairableObjs[i].GetComponent<distructableObjs>().overrideMaterial = canBuildPreview;
                    }
                    else
                    {
                        repairableObjs[i].GetComponent<distructableObjs>().overrideMaterial = cannotBuildPreview;
                    }
                }
            }
            else
            {
                //Disable anyoverride
                planks[i].GetComponent<distructableObjs>().matOverrideFlag = false;
            }
        }
    }

}
