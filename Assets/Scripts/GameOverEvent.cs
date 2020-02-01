using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverEvent : MonoBehaviour
{

    string pathPrefix = @"file://";
    string filename = @"gameoverscreen.png";

    bool IOLOCK = false;

    public void ScreenShot()
    {
        if (!IOLOCK)
        {
            StartCoroutine(CaptureScreenShot());
        }
    }

    private void Start()
    {
        StartCoroutine(LoadScreenShot());
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && !IOLOCK)
        {
            StartCoroutine(CaptureScreenShot());
        }
    }

    IEnumerator CaptureScreenShot()
    {
        IOLOCK = true;

        ScreenCapture.CaptureScreenshot("gameoverscreen.png");

        //Wait for IO
        yield return new WaitForSeconds(1.0f);

        IOLOCK = false;
        yield return null;
    }

    IEnumerator LoadScreenShot()
    {
        IOLOCK = true;

        string path = Directory.GetCurrentDirectory() + "\\Meteor Storm_Data\\";
        string fullFilename = pathPrefix + path + filename;

        Debug.LogError(fullFilename);

        WWW www = new WWW(fullFilename);
        Texture2D screenshot = new Texture2D(1920, 1080, TextureFormat.DXT1, false);
        www.LoadImageIntoTexture(screenshot);
        GameObject.FindGameObjectWithTag("GAMEOVERSCREEN").GetComponent<MeshRenderer>().material.SetTexture("Texture2D_56079B38", screenshot);
        
        IOLOCK = false;

        yield return null;
    }

}
