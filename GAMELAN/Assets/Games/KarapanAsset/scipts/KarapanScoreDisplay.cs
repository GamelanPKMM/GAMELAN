using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KarapanScoreDisplay : KarapanSubScontroller {
    private string initialText;
    private Text textUI;
	// Use this for initialization
	void Start () {
        textUI = GetComponent<Text>();
        initialText = textUI.text;
	}
	
	// Update is called once per frame
	void Update () {
     //   textUI.text = initialText + (int)gameControl.scoreControl.score;
	}
}
