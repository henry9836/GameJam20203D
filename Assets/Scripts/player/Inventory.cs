using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int maxInvSize = 4;
    private int currentInvSize = 0;

    public enum ITEM
    {
        UNASSIGNED,
        WOOD,
        STONE
    };

    Dictionary<ITEM, int> inventory = new Dictionary<ITEM, int>();

    public bool UpdateInv(ITEM item, int amount)
    {
        //Get current amount
        int newVal = inventory[item];

        //Get new amount
        newVal += amount;

        //If we are adding to our inv
        if (amount >= 1)
        {
            //If we have space
            if ((currentInvSize < maxInvSize) && (currentInvSize + amount <= maxInvSize))
            {
                //Modify inv
                inventory[item] = newVal;

                //Update size of inv
                currentInvSize += amount;

                return true;
            }
        }
        //If we are removing
        else
        {
            //If we can remove without going below 0
            if (newVal >= 0)
            {
                //Modify inv
                inventory[item] = newVal;

                //Update size of inv
                currentInvSize += amount;

                return true;
            }
        }
        return false;
    }

    private void Start()
    {
        //Add inv items
        inventory.Add(ITEM.STONE, 0);
        inventory.Add(ITEM.WOOD, 0);

        //Test inv
        //Debug.Log("Test 1: " + "INV SIZE: " + currentInvSize.ToString() + " STONE: " + inventory[ITEM.STONE].ToString() + " WOOD: " + inventory[ITEM.WOOD]);
        //UpdateInv(ITEM.WOOD, 3);
        //Debug.Log("Test 2: " + "INV SIZE: " + currentInvSize.ToString() + " STONE: " + inventory[ITEM.STONE].ToString() + " WOOD: " + inventory[ITEM.WOOD]);
        //UpdateInv(ITEM.STONE, 1);
        //Debug.Log("Test 3: " + "INV SIZE: " + currentInvSize.ToString() + " STONE: " + inventory[ITEM.STONE].ToString() + " WOOD: " + inventory[ITEM.WOOD]);
        //UpdateInv(ITEM.WOOD, 1);
        //Debug.Log("Test 3: " + "INV SIZE: " + currentInvSize.ToString() + " STONE: " + inventory[ITEM.STONE].ToString() + " WOOD: " + inventory[ITEM.WOOD]);
        //UpdateInv(ITEM.WOOD, -2);
        //Debug.Log("Test 4: " + "INV SIZE: " + currentInvSize.ToString() + " STONE: " + inventory[ITEM.STONE].ToString() + " WOOD: " + inventory[ITEM.WOOD]);

    }


}
