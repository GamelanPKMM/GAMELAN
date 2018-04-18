using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialScript : SubController {
    public Sprite[] tutorial;
    private int tutorNo =-1;
    [SerializeField]
    private Image tutorRenderer;
    void reset() {
        basicGameControl.removeEvent("Reset", reset);
        Destroy(gameObject);
    }
    protected override void start()
    {
        base.start();
        basicGameControl.addEvent("Reset", reset);
        transform.GetChild(0).gameObject.SetActive(true);
        tutorRenderer = transform.GetChild(0).gameObject.GetComponent<Image>();
        changeTutor();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            changeTutor();
        }
    }

    void changeTutor() {
        if (++tutorNo < tutorial.Length)
        {
            tutorRenderer.sprite = tutorial[tutorNo];
        }
        else basicGameControl.resetGame();
    }
}
