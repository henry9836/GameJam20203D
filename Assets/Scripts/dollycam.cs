using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dollycam : MonoBehaviour
{
    public bool once = true;
    public bool atobestart = false;

    private GameObject player;

    void Start()
    {
        StartCoroutine(atob());
        StartCoroutine(GameObject.Find("GameManager").GetComponent<musicmanager>().menuIN());
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
    }

    void Update()
    {
        GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Text>().text = "";

        if (AnimatorIsPlaying() == false && once == true && atobestart == true)
        {
            GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Text>().text = "Press esc to quit, any other key to begin";

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            else if (Input.anyKeyDown == true)
            {
 
                once = false;
                StartCoroutine(btoc());
                StartCoroutine(GameObject.Find("GameManager").GetComponent<musicmanager>().menutoBG());

            }
        }
    }



    public IEnumerator atob()
    {
        yield return new WaitForSeconds(2.0f);
        atobestart = true;
        this.gameObject.GetComponent<Animator>().SetInteger("Stage", 0);
        yield return null;
    }

    public IEnumerator btoc()
    {
        this.gameObject.GetComponent<Animator>().SetInteger("Stage", 1);

        yield return new WaitForSeconds(2.0f);

        while (AnimatorIsPlaying() == true)
        {
            yield return null;
        }

        if (AnimatorIsPlaying() == false)
        {
            GameObject.Find("GameManager").GetComponent<score>().thescore = 0.0f;
            player.SetActive(true);

            Destroy(this.gameObject);
        }

        yield return null;
    }

    bool AnimatorIsPlaying()
    {
        return this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}
