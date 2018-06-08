using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningText : MonoBehaviour{

    public static void runningText(string stext, float dur, Text text) {
        RunningText run = new RunningText();
        run.StartCoroutine(runText(stext, dur, text));
    }

    static IEnumerator runText(string stext, float dur, Text text) {
        float dTime = dur / stext.Length;
        for (int i = 0; i < stext.Length; i++) {
            text.text += stext[i];
            yield return new WaitForSecondsRealtime(dTime);
        }
    }
	
}
