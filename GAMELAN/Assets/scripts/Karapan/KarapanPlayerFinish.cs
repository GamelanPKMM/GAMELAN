using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanPlayerFinish : KarapanSubScontroller {
    private Vector3 targetV;
    private Vector3 startV;
    private float startAnim;
    private float animDur = 1.5F;
    private float journey = 0;
    private bool a= true;
    protected override void start()
    {
        base.start();
        gameControl.addEvent("Finish", finished);

    }
    protected override void instantiate<T>()
    {
        base.instantiate<T>();
        gameControl.addNewEventType("PlayerFinishAnimateDone");
    }
    void Update() {
        if (gameControl.getIsFinish()&&a) {
            journey = (Time.time - startAnim)/animDur;
            transform.position = Vector3.Lerp(startV, targetV, journey);
            if(journey>=1){
                a = false;
                gameControl.callEvent("PlayerFinishAnimateDone");
            }
        }
    }
    void finished() {
        startV = transform.position;
        targetV = new Vector3(startV.x, 10, 0);

        startAnim = Time.time;
    }
}
