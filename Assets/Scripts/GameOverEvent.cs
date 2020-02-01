using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverEvent : MonoBehaviour
{

    string pathPrefix = @"file://";
    string filename = @"gameoverscreen.png";

    public void CaptureAndLoadScreenShot()
    {
        ScreenCapture.CaptureScreenshot("gameoverscreen.png");

        string path = Directory.GetCurrentDirectory() + "\\";
        string fullFilename = pathPrefix + path + filename;

        Debug.Log(fullFilename);

        WWW www = new WWW(fullFilename);
        Texture2D screenshot = new Texture2D(1024, 1024, TextureFormat.DXT1, false);
        www.LoadImageIntoTexture(screenshot);

        GameObject.FindGameObjectWithTag("GAMEOVERSCREEN").GetComponent<MeshRenderer>().material.SetTexture("Texture2D_56079B38", screenshot);

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            CaptureAndLoadScreenShot();
        }
    }

}
