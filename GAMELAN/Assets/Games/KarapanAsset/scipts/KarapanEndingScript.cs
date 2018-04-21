using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanEndingScript : KarapanSubScontroller {

    public void gameOver() {
        gameObject.SetActive(true);
    }
    public void reset() {
        gameObject.SetActive(false);
    }
    public void exit() {
        basicGameControl.exitGame();
    }
    protected override void start() {
        base.start();
        gameControl.addEvent("GameOver", gameOver);
        gameControl.addEvent("Reset", reset);
        reset();
    }
}
