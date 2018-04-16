using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {
    public Rigidbody2D rb2;
    public static ScrollBackground Sb;
    // Use this for initialization
    void Start () {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(-GameControl.instance.scrollSpeed,0);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameControl.instance.gameOver == true) 
        {
            rb2.velocity = Vector2.zero;
        }
    }
}
