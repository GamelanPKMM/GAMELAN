using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarapanStarUIControl : KarapanSubScontroller{
    public GameObject[] stars;
    private StarController controller;
    public GameObject starControl;
    private Vector3 starOriPos;
    private Vector3 starOriScale;
    protected override void start()
    {
        base.start();
        starControl.SetActive(false);
        controller = basicGameControl.SubController<StarController>("StarController");
        stars = new GameObject[controller.maksStar];
        starOriPos = starControl.transform.position;
        starOriScale = starControl.transform.localScale;
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
        StartCoroutine(animate(stars[controller.getStar() - 1].transform));
    }


    IEnumerator animate(Transform target) {
        basicGameControl.setGameState(false);
        starControl.SetActive(true);
        starControl.transform.position = starOriPos;
        starControl.transform.localScale = starOriScale;
        starControl.GetComponent<Image>().sprite = target.gameObject.GetComponent<Image>().sprite;
        float interpol = 0;
        yield return new WaitForSecondsRealtime(1);
        do
        {
            interpol += 0.2F * Time.unscaledDeltaTime;
            starControl.transform.position = Vector3.Lerp(starControl.transform.position, target.position, interpol);
            starControl.transform.localScale = Vector3.Lerp(starControl.transform.localScale, target.localScale, interpol);
            yield return new WaitForEndOfFrame();
        } while (interpol < 0.5);
        starControl.transform.position = target.position;
        starControl.transform.localScale = target.localScale;
        stars[controller.getStar() - 1].SetActive(true);
        basicGameControl.setGameState(true);
        starControl.SetActive(false);
        basicGameControl.SubController<KarapanStartScript>("KarapanStartScript").countDown();
    }
}
