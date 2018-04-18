using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanStarUIControl : KarapanSubScontroller{
    public GameObject[] stars;
    private StarController controller;
    protected override void start()
    {
        base.start();
        controller = basicGameControl.SubController<StarController>("StarController");
        stars = new GameObject[controller.maksStar];
        loadStar();
        basicGameControl.addEvent("Reset", resetStar);
        basicGameControl.addEvent("GetStar", getStar);
    }

    void loadStar() { 
        for(int i = 0; i < stars.Length; i++){
            stars[i] = transform.GetChild(i).gameObject;
        }
        resetStar();
    }

    void resetStar() {
        foreach (GameObject star in stars) {
            star.SetActive(false);
        }
    }

    void getStar() {
        stars[controller.getStar()-1].SetActive(true);
    }
}
