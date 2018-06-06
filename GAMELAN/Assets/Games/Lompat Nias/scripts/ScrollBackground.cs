using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {
    public GameObject bg1;
    public GameObject bg2;
    private Rigidbody2D rb21;
    private Rigidbody2D rb22;
    public float speed = 1f;
    // Use this for initialization

    void Start () {
        rb21 = bg1.GetComponent<Rigidbody2D>();
        rb21.velocity = new Vector2(-GameControl.instance.scrollSpeed * speed, 0);
        rb22 = bg2.GetComponent<Rigidbody2D>();
        rb22.velocity = new Vector2(-GameControl.instance.scrollSpeed * speed, 0);
    }
  
    // Update is called once per frame
    public void StopBackground()
    {
        rb21.velocity = Vector2.zero;
        rb22.velocity = Vector2.zero;
    }

    public void updateSpeed(float scrollSpeed)
    {
        rb21.velocity = new Vector2(-scrollSpeed * speed, 0);
        rb22.velocity = new Vector2(-scrollSpeed * speed, 0);
    }
}
