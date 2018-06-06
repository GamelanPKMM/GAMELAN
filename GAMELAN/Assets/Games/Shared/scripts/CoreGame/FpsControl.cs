using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsControl : MonoBehaviour
{
    public int fps = 60;
    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = fps;
    }

    void setFps(int fps)
    {
        Application.targetFrameRate = fps;
    }
}