using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//switch to different camera
public class ToggleCamera : MonoBehaviour
{
    public Camera cameraMain;
    public Camera cameraOther;

    public void switchCam(int x)
    {
        deactivateall();
        if (x == 1)
        {
            cameraMain.enabled = true;
        }else if (x == 2)
        {
            cameraOther.enabled = true;
        }
    }

    private void deactivateall()
    {
        cameraOther.enabled = false;
        cameraMain.enabled = false;
    }
}
