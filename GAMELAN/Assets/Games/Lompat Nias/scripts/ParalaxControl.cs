using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxControl : MonoBehaviour {
    public ScrollBackground[] bg;
    public static ParalaxControl self;
    // Use this for initialization

    private void Awake()
    {
        if (self == null)
        {
            self = this;
        }
        else if (self != this)
        {
            Destroy(gameObject);
        }
    }

    //fungsi unutk mengupdate speed pada background
    public void updateSpeed(float speed)
    {
        for (int i = 0; i < bg.Length; i++)
        {
            bg[i].updateSpeed(GameControl.instance.scrollSpeed);
        }
    }

    //fungsi untuk menstop background
    public void StopBackground()
    {
        for (int i = 0; i < bg.Length; i++)
        {
            bg[i].StopBackground();
        }
    }
}
