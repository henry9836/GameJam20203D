using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inventoryUI : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        this.gameObject.GetComponent<Image>().fillAmount = (float)player.GetComponent<Inventory>().currentInvSize / (float)player.GetComponent<Inventory>().maxInvSize;
    }
}
