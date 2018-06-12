using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialNias : MonoBehaviour {

    public Sprite[] tutorial;
    private int tutorNo = -1;
    private Image tutorRenderer;

    private void Start()
    {
        if (GameControl.tutorialNias == true)
        {
            GameControl.instance.birdPause();
            transform.GetChild(0).gameObject.SetActive(true);
            tutorRenderer = transform.GetChild(0).gameObject.GetComponent<Image>();
            changeTutor();
            GameControl.tutorialNias = false;
        }
        else
        {
            Destroy(gameObject);
        }
        
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
        else
        {
            GameControl.instance.birdPause();
            Destroy(gameObject);
        }
    }
}
