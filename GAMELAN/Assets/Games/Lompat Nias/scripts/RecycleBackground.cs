using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleBackground : MonoBehaviour {
    private BoxCollider2D groundCollider;
    private float backgroundLength;
	// Use this for initialization
    //Mencari size sumbu x dari backgroud
	void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        backgroundLength = groundCollider.size.x;
	}

    // Update is called once per frame

    private void FixedUpdate()
    {
        //jika background bertransformasi sampai ukurnnya maka akan di transformasi ke kanan sejauh size sumbu xnya
        if (transform.position.x < -backgroundLength * 1f)
        {
            RecyleBackground();
           //Debug.Log("transisi x : " + transform.position.x);
        }
    }
    //method untuk metransformasi
    private void RecyleBackground()
    {
        Vector2 offset = new Vector2(backgroundLength * 2f, 0);
        transform.position =  ((Vector2)transform.position) + offset;
    }
}
