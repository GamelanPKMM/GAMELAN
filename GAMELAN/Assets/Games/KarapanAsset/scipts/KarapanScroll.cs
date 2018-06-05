using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanScroll : KarapanSubScontroller {
    private Vector3[] startPos;
    public GameObject Target;
    public GameObject Start;
    private GameObject[] back;

    protected override void start()
    {
        base.start();
        back = GameObject.FindGameObjectsWithTag("Background");
        startPos = new Vector3[back.Length];
        for (int i = 0; i < back.Length; i++)
        {
            // startPos[i] = back[0].transform.localPosition;
            startPos[i] = back[i].transform.position;
        }
        gameControl.addEvent("Reset", reset);

    }
	
	// Update is called once per frame
    void Update()
    {
        if (!gameControl.isPause() && gameControl.getGameState())
        {
            for (int i = 0; i < back.Length; i++)
            {

                back[i].transform.Translate(Vector2.down * (Time.deltaTime * gameControl.speedControl.speed));
                if (back[i].transform.position.y <= Target.transform.position.y)
                {
                    back[i].transform.position = Start.transform.position;
                }
            }
       }
    }
    

    void reset() {
        for (int i = 0; i < back.Length; i++)
        {
            back[i].transform.position = startPos[i];
        }
    }

}
