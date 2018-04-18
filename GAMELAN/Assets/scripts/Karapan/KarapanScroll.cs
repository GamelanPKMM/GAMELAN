using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanScroll : KarapanSubScontroller {
    private Vector3 startPos;
    private GameObject back;

    protected override void start()
    {
        base.start();
        back = GameObject.FindGameObjectWithTag("Background");
        startPos = back.transform.localPosition;
        startPos = transform.position;
        startPos.y = 10;
        gameControl.addEvent("Reset", reset);

    }
	
	// Update is called once per frame
    void Update()
    {
        if (!gameControl.isPause() && gameControl.getGameState())
        {
            back.transform.Translate(Vector2.down * (Time.deltaTime * gameControl.speedControl.speed));
                if (back.transform.position.y <= -10)
                {
                    back.transform.position = startPos;
                }
       }
    }
    

    void reset() {
        back.transform.position = startPos;
    }

}
