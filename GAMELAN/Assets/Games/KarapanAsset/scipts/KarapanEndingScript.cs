using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarapanEndingScript : KarapanSubScontroller {
    private Text text;
    public void gameOver() {
        if (basicGameControl.getIsFinish())
        {
            text.text = "Selamat kamu menang!";
            //PenghargaanController.self.tambahPenghargaan("Karapan Bintang 5");
        }
        else {
            text.text = "Kamu kalah!";
        }
        gameObject.SetActive(true);
    }
    public void reset() {
        gameObject.SetActive(false);
    }
    public void exit() {
        basicGameControl.exitGame();
    }

    public void resetButtonClick() {
        if (basicGameControl.isWinning()) {
            basicGameControl.saveGame();
        }
        basicGameControl.resetGame();
    }
    public void exitButtonClick() {
        basicGameControl.exitGame();
    }
    protected override void start() {
        base.start();
        text = gameObject.transform.Find("EndingText").GetComponent<Text>();
        gameControl.addEvent("GameOver", gameOver);
        gameControl.addEvent("Reset", reset);
        reset();
    }
}
