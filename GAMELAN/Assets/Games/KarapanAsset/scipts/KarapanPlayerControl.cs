using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanPlayerControl : KarapanSubScontroller {
    private GameObject player;
    private Vector3 targetPlayerPos;
    private Vector3 intialPlayerPos = new Vector3(0, -3.5F, 0);
    private bool isTransititioning = false;
    private int currentTransPosCode = 0;
    private int pos = 0;
    private float flatMaxRelativeTransSpeed = 0.5F;
    private float flatSpeed = 0.5F;
    private float transJourney = 0F;
    private float startTrans;
    protected override void start()
    {
        base.start();
        player = GameObject.Find("Player");
        targetPlayerPos = player.transform.localPosition;
        GameObject child = transform.GetChild(0).gameObject;

        gameControl.addEvent("Reset", reset);
    }
	
	// Update is called once per frame
	void Update () {
        movePlayer();
	}
    void FixedUpdate() {
        stopAnim();
    }

 

    private float getTransReal(int poscode) {
        return (poscode) * (float)2.5;
    }

    private void movePlayer() {
        if (!gameControl.isPause() && gameControl.getGameState())
        {

            float transvalue = ((gameControl.speedControl.speed / gameControl.speedControl.speedcap) * flatMaxRelativeTransSpeed + flatSpeed);
            transJourney += (Time.time - startTrans) * transvalue;
            transform.position = Vector3.Lerp(transform.position, targetPlayerPos, transJourney);
        }
        else startTrans += Time.deltaTime;
    }
    private void stopAnim()
    {
        if (transJourney >= 1)
        {
            isTransititioning = false;
            currentTransPosCode = 0;
            transJourney = 0;
        }
    }
    public void registerMove(int posCode){
        if (!isTransititioning && !gameControl.isPause() && gameControl.getGameState())
        {
            if (posCode == -1 && pos > -2 || pos < 2 && posCode == 1)
            {
                pos += posCode;
                isTransititioning = true;
                targetPlayerPos.x = targetPlayerPos.x + getTransReal(posCode); ;
                currentTransPosCode = posCode;
                transJourney = 0;
                startTrans = Time.time;
            }
        }
    }



    void reset() {
        targetPlayerPos = intialPlayerPos;
        pos = 0;
    }
    
}
