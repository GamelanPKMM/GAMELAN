using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KarapanProgressBarUI : KarapanSubScontroller{
    private Image progressBarImage;

    protected override void start()
    {
        base.start();
        progressBarImage = GetComponent<Image>();
        progressBarImage.type = Image.Type.Filled;
        progressBarImage.fillMethod = Image.FillMethod.Horizontal;
    }

    void drawProgress() {
        progressBarImage.fillAmount= gameControl.progressControl.progress / gameControl.progressControl.maxCap ;
    }
    void Update() {
        drawProgress();
    }
    
}
