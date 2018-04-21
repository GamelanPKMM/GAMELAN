using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameAndTimeDisplay : SubController
{
    public Text textUI;
    public bool DisplayFPS, DisplayFrameCount, DisplayAverageFPS, DisplayTime;
    void Update()
    {
        if (basicGameControl.isDebugState())
        {
            float fps = 1 / UnityEngine.Time.deltaTime;
            long frameCount = UnityEngine.Time.frameCount;
            float averageFPS = frameCount / UnityEngine.Time.time;
            float time = UnityEngine.Time.time;
            string text = "";
            text = text + (DisplayFPS ? "FPS = " + fps + " \n" : "");
            text = text + (DisplayFrameCount ? "FrameCount = " + frameCount + " \n" : "");
            text = text + (DisplayAverageFPS ? "Average FPS = " + averageFPS + " \n" : "");
            text = text + (DisplayTime ? "Time = " + time + " \n" : "");
            textUI.text = text;
        }
        else textUI.text = "";

    }

    protected override void start()
    {
        base.start();
        textUI = gameObject.GetComponent<Text>();
    }
}
