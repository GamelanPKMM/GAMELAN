using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarapanStartScript : KarapanSubScontroller {
    public Sprite[] number;
    public Image image;
    public float waitFor = 1;
    protected override void start()
    {
        base.start();
        basicGameControl.addSubController("KarapanStartScript", this);
        basicGameControl.addEvent("Reset", resetGame);

    }

    void resetGame()
    {
        countDown();
    }
    IEnumerator countDownCor()
    {
        basicGameControl.setGameState(false);
        image.gameObject.SetActive(true);
        foreach (Sprite s in number)
        {
            image.sprite = s;
            yield return new WaitForSecondsRealtime(waitFor);

        }
        basicGameControl.setGameState(true);
        image.gameObject.SetActive(false);
    }

    public void countDown() {
            StartCoroutine(countDownCor());
    }

    
}
