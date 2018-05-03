using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeControlUI : MonoBehaviour {
    public GameObject[] life = new GameObject[3];
    public static lifeControlUI instance;
    private int lifeCount = 0;
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
        for (int i = 0; i < life.Length; i++)
        {
            life[i].SetActive(true);
        }
        lifeCount = GameControl.instance.life;
    }

    private void resetLife()
    {
        for (int i = 0; i < life.Length; i++)
        {
            life[i].SetActive(false);
        }
    }

    public void UpdateLife()
    {
        resetLife();
        lifeCount = GameControl.instance.life;
        for (int i = 0; i < lifeCount; i++)
        {
            life[i].SetActive(true);
        }
    }
}
