using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicmanager : MonoBehaviour
{
    public AudioClip menu;
    public AudioClip BG;
    public AudioSource source;

    public float menuvol = 0.75f;
    public float BGvol = 1.0f;


    public IEnumerator menuIN()
    {
        source.clip = menu;
        source.volume = 0.0f;
        source.Play();

        for (float t = 0.0f; t < 1.0f; t += Time.unscaledDeltaTime * 0.5f)
        {
            source.volume = Mathf.Lerp(0.0f, menuvol, t);
            yield return null;
        }
        source.volume = menuvol;
    }

    public IEnumerator menutoBG()
    {
        for (float t = 0.0f; t < 1.0f; t += Time.unscaledDeltaTime * 0.5f)
        {
            source.volume = Mathf.Lerp(menuvol, 0.0f, t);
            yield return null;
        }
        source.clip = BG;
        source.Play();

        for (float t = 0.0f; t < 1.0f; t += Time.unscaledDeltaTime * 0.5f)
        {
            source.volume = Mathf.Lerp(0.0f, BGvol, t);
            yield return null;
        }
        source.volume = BGvol;


    
    }


    public IEnumerator BGout()
    {
        for (float t = 0.0f; t < 1.0f; t += Time.unscaledDeltaTime * 0.5f)
        {
            source.volume = Mathf.Lerp(BGvol, 0.0f, t);
            yield return null;
        }
        source.volume = 0.0f;


    }
}
