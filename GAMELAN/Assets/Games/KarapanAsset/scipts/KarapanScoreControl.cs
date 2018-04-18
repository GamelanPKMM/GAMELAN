using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanScoreControl : KarapanSubScontroller {
    public float score = 0;
    public float bias = 1;
    protected override void start()
    {
        base.start();
        gameControl.addEvent("Reset", reset);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!gameControl.isPause() && gameControl.getGameState())
        score += Time.fixedDeltaTime* bias;
	}

    void reset() {
        score = 0;
    }
}
