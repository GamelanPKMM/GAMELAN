using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {
    public GameObject bg1;
    public GameObject bg2;
    private static Rigidbody2D rb21;
    private static Rigidbody2D rb22;
    public static ScrollBackground Sb;
    // Use this for initialization
    void Start () {
        rb21 = bg1.GetComponent<Rigidbody2D>();
        rb21.velocity = new Vector2(-GameControl.instance.scrollSpeed,0);
        rb22 = bg2.GetComponent<Rigidbody2D>();
        rb22.velocity = new Vector2(-GameControl.instance.scrollSpeed,0);
    }
	// Update is called once per frame
	void Update () {
        if (GameControl.instance.stopBird == true) 
        {
            rb21.velocity = Vector2.zero;
            rb22.velocity = Vector2.zero;
        }
    }
    public static void updateSpeed(float scrollSpeed)
    {
        rb21.velocity = new Vector2(-scrollSpeed, 0);
        rb22.velocity = new Vector2(-scrollSpeed, 0);
    }
}
