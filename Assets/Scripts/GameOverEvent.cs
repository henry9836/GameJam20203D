using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverEvent : MonoBehaviour
{
    public void CaptureAndLoadScreenShot()
    {
        Debug.Log("Capturing Screenshot...");
        ScreenCapture.CaptureScreenshot("gameoverscreen.png");
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            CaptureAndLoadScreenShot();
        }
    }

}
