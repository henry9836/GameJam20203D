using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dollycam : MonoBehaviour
{
    public bool once = true;

    void Start()
    {
        StartCoroutine(atob());
    }

    void Update()
    {
        if (AnimatorIsPlaying() == false)
        {
            if (Input.anyKeyDown == true)
            {
                if (once == true)
                {
                    once = false;
                    StartCoroutine(btoc());
                }
            }
        }
    }



    public IEnumerator atob()
    {
        yield return new WaitForSeconds(2.0f);
        this.gameObject.GetComponent<Animator>().SetInteger("Stage", 0);
        //this.gameObject.GetComponent<Animator>().Play("atob");
        yield return null;
    }

    public IEnumerator btoc()
    {
        

        //this.gameObject.GetComponent<Animator>().Play("btoc");
        this.gameObject.GetComponent<Animator>().SetInteger("Stage", 1);

        yield return new WaitForSeconds(2.0f);

        while (AnimatorIsPlaying() == true)
        {
            yield return null;
        }

        if (AnimatorIsPlaying() == false)
        {
            Destroy(this.gameObject);
        }

        yield return null;
    }

    bool AnimatorIsPlaying()
    {
        return this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}
