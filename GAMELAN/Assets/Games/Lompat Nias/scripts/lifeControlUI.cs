using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeControlUI : MonoBehaviour {
    public GameObject[] life = new GameObject[3];
    public static lifeControlUI lifeControl;
    private int lifeCount = 0;
    // Use this for initialization
    private void Start()
    {
        for (int i = 0; i < life.Length; i++)
        {
            life[i].SetActive(true);
        }
        lifeCount = GameControl.instance.life;
    }

    private void FixedUpdate()
    {
        lifeCount = GameControl.instance.life;
        if (lifeCount < 3)
        {
           life[lifeCount].SetActive(false);
        }
    }
}
