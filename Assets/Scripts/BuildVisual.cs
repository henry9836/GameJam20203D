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
    private GameObject cam;

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
        cam = GameObject.FindGameObjectWithTag("MainCamera");

        StartCoroutine(VisualLoop());

    }

    IEnumerator VisualLoop()
    {
        while (true)
        {
            //Change visual of planks when damaged and nearby
            for (int i = 0; i < repairableObjs.Count; i++)
            {
                //Check distance
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
                            canBuild = (player.GetComponent<Inventory>().inventory[Inventory.ITEM.WOOD] >= cam.GetComponent<RepairMechanic>().costForPlank);
                        }
                        else if (repairableObjs[i].tag == "Tile")
                        {
                            canBuild = (player.GetComponent<Inventory>().inventory[Inventory.ITEM.STONE] >= cam.GetComponent<RepairMechanic>().costForTile);
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
                    else
                    {
                        //Disable anyoverride
                        repairableObjs[i].GetComponent<distructableObjs>().matOverrideFlag = false;
                    }
                }
                else
                {
                    //Disable anyoverride
                    repairableObjs[i].GetComponent<distructableObjs>().matOverrideFlag = false;
                }
            }
            yield return null;
        }
    }

}
