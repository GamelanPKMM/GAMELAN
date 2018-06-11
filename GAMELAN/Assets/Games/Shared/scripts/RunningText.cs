using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RunningText : MonoBehaviour{
    public static List<RunningText> list = new List<RunningText>();
    float deltaTime = 0;
    float realDeltaTime = 0;
    public static Coroutine runningText(string stext, float dur, Text text) {
        float dTime = dur / stext.Length;
        return runningText(stext, text, dTime);
    }
    public static Coroutine runningText(string stext, float dur, Text text, UnityAction action)
    {
        float dTime = dur / stext.Length;
        return runningText(stext, text, dTime, action);
    }
    public static Coroutine runningText(string stext, Text text, float deltaTime) {
        GameObject parent = new GameObject("RunningText");
        RunningText r = parent.AddComponent<RunningText>();
        list.Add(r);
        return r.StartCoroutine(runText(parent, stext, deltaTime, text));

    }
    public static Coroutine runningText(string stext, Text text, float deltaTime, UnityAction action)
    {
        GameObject parent = new GameObject("RunningText");
        RunningText r = parent.AddComponent<RunningText>();
        list.Add(r);
        return r.StartCoroutine(runText(parent, stext, deltaTime, text, action));

    }
    static IEnumerator runText(GameObject parent,string stext, float dTime, Text text) {
        RunningText r = parent.GetComponent<RunningText>();
        r.deltaTime = dTime;
        for (int i = 0; i < stext.Length; i++) {
            text.text += stext[i];
            yield return new WaitForSecondsRealtime(r.realDeltaTime);
        }
        Destroy(parent);
        list.Remove(parent.GetComponent<RunningText>());
    }
    static IEnumerator runText(GameObject parent, string stext, float dTime, Text text, UnityAction action)
    {
        yield return runText(parent, stext, dTime, text);
        action.Invoke();
        yield return null;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            realDeltaTime = deltaTime / 5;
        }
        else {
            realDeltaTime = deltaTime;
        }
    }

}
