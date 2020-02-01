using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public float thescore = 0.0f;
    public GameObject scoreUI;

    void Update()
    {
        addscore(0.1f * Time.deltaTime);
    }

    public void addscore(float ammount)
    {
        thescore += ammount;
        scoreUI.GetComponent<Text>().text = "Score: " + thescore.ToString("F0");
    }
}
