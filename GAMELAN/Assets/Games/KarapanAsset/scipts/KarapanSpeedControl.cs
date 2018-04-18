using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanSpeedControl : KarapanSubScontroller {
    public float speed = 6F;
    public float accel = 1F;
    public float speedcap = 14F;
    public float lowerspeedcap = 6F;
    private float startTime = 0;

    protected override void start()
    {
        base.start();
        gameControl.userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.UpArrow, KeyCode.W }, "IncreaseSpeed", delegate() { if (gameControl.isDebugState())increaseSpeed(); }, UserInputControl.SometimePress));
        gameControl.userInputControl.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.DownArrow, KeyCode.S }, "DecreaseSpeed", delegate() { if (gameControl.isDebugState()) decreaseSpeed(); }, UserInputControl.SometimePress));
        gameControl.addEvent("Reset", reset);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!gameControl.isPause() && gameControl.getGameState())
            speed = Mathf.Log10(Time.time - startTime+1)*accel+lowerspeedcap;
        else startTime += Time.fixedDeltaTime;
        speedCap();
	}

    public void increaseSpeed() {
        speed += speed >= speedcap ? 0 : 10 * accel;
    }
    public void decreaseSpeed()
    {
        speed -= speed <= lowerspeedcap ? 0 : 10 * accel;
    }
    private void speedCap() {
        if (speed >= speedcap) {
            speed = speedcap;
        }
        else if (speed < lowerspeedcap) {
            speed = lowerspeedcap;
        }
    }

    void reset() {
        speed = lowerspeedcap;
        startTime = Time.time;
    }

}
