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
        basicGameControl.addEvent("Reset", resetGame);

    }

    void resetGame()
    {
        basicGameControl.setGameState(false);
        StartCoroutine(countDown());    }

    IEnumerator countDown()
    {
        image.gameObject.SetActive(true);
        foreach (Sprite s in number)
        {
            image.sprite = s;
            yield return new WaitForSecondsRealtime(waitFor);

        }
        basicGameControl.setGameState(true);
        image.gameObject.SetActive(false);
    }
}
