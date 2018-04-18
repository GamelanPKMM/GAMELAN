using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanEndingScript : KarapanSubScontroller {

    void gameOver() {
        gameObject.SetActive(true);
    }
    void reset() {
        gameObject.SetActive(false);
    }
    protected override void start() {
        base.start();
        gameControl.addEvent("PlayerFinishAnimateDone", gameOver);
        gameControl.addEvent("Reset", reset);
        reset();
    }
}
