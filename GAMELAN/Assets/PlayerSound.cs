using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {
    public static PlayerSound self;
    public AudioClip idle;
    public AudioClip flash;
    public AudioClip hit;
    public AudioClip jump;
    public AudioClip earncoin;
    public AudioClip earnStar;
    public AudioClip finish;
    public AudioClip gameOver;

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
}
