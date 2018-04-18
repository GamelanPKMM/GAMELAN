using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanEnemyInstanceControl : KarapanSubScontroller {
    public bool isAffected = false;
    private float speedSpeed = 0.3F;
    private float startTrans;
    public Vector3 targetVector;
    public Vector3 OriPos;
    private float transJourney = 0;
    protected override void start()
    {
        base.start();
        startTrans = Time.time;
        OriPos = transform.position;
        targetVector = transform.position;
        targetVector.y = -transform.position.y;
        gameControl.addEvent("Reset", reset);
    }
	void FixedUpdate () {
        if (!gameControl.isPause() && gameControl.getGameState() && isAffected)
        {
            float transvalue = ((gameControl.speedControl.speed / gameControl.speedControl.speedcap + 0.15F) * speedSpeed);
            transJourney = (Time.time - startTrans) * transvalue;
            transform.position = Vector3.Lerp(OriPos, targetVector, transJourney);

        }
        else {
            startTrans += Time.fixedDeltaTime;
        }
        if (transJourney >= 1 && gameObject != null)
        {
            gameControl.removeEvent("Reset", reset);
            Destroy(gameObject);
        }
	}

    void reset() {
        if (isAffected && gameObject != null)
        {
            gameControl.removeEvent("Reset", reset);
            Destroy(gameObject);
        }
    }
}
