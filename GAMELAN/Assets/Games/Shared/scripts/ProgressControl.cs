using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressControl : SubController {
    public float maxCap = 100;
    public float endCap = 200;
    public float gameInSecond = 120;
    public float pps;
    public float progress = 0;
    public float minProgress = 0;
    private int delta;
    private bool a = true;
    protected override void start()
    {
        base.start();
        pps = endCap / gameInSecond;
        delta = endCap - minProgress > 0 ? 1 : -1;
        basicGameControl.addEvent("Reset", reset);
        reset();
    }

    void FixedUpdate()
    {
        update_Progress();

	}
    void update_Progress() {
        if (!basicGameControl.isPause() && basicGameControl.getGameState())
            progress += Time.fixedDeltaTime * pps* delta;
        progressEnd();
    }
    void progressEnd() {
        if (progress >= endCap && a) {
            basicGameControl.FinishGame();
            a = false;
        }
    }
    void reset(){
        progress = minProgress;
        a = true;
    }

}
