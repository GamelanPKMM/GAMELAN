using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarControl : MonoBehaviour {
    public GameObject[] star = new GameObject[5];
    public static StarControl instance;
    private int starCount = 0;
    // Use this for initialization

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < star.Length; i++)
        {
            star[i].SetActive(false);
        }
        starCount = GameControl.instance.star;
    }

    private void resetStar()
    {
        for (int i = 0; i < star.Length; i++)
        {
            star[i].SetActive(false);
        }
    }

    public void UpdateStar()
    {
        resetStar();
        starCount = GameControl.instance.star;
        for (int i = 0; i < starCount; i++)
        {
            star[i].SetActive(true);
        }
    }
}
