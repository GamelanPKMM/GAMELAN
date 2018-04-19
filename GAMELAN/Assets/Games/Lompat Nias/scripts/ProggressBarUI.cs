using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProggressBarUI : MonoBehaviour {
    public Image progressBarImage;

     void start()
    {
        progressBarImage = GetComponent<Image>();
        progressBarImage.type = Image.Type.Filled;
        progressBarImage.fillMethod = Image.FillMethod.Horizontal;
        progressBarImage.fillAmount = 0.5f;
    }

    private void Update()
    {
        progressBarImage.fillAmount = GameControl.instance.timeFinish / GameControl.instance.maxTime;
    }
}
