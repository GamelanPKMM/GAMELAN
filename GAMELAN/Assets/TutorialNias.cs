using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialNias : MonoBehaviour {

    public Sprite[] tutorial;
    private int tutorNo = -1;
    [SerializeField]
    private Image tutorRenderer;
    void reset()
    {

        Destroy(gameObject);
    }
    protected void start()
    {
        GameControl.instance.birdPause();
        transform.GetChild(0).gameObject.SetActive(true);
        tutorRenderer = transform.GetChild(0).gameObject.GetComponent<Image>();
        changeTutor();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            changeTutor();
        }
    }

    void changeTutor()
    {
        if (++tutorNo < tutorial.Length)
        {
            tutorRenderer.sprite = tutorial[tutorNo];
        }
        else GameControl.instance.birdPause();
    }
}
