using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairMechanic : MonoBehaviour
{

    public int costForPlank = 1;
    public int costForTile = 1;
    public LayerMask buildLayer;

    private RaycastHit hit;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, buildLayer))
            {

            }
        }
    }
}
