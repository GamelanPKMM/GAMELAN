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
	void Update () {
        //jika background bertransformasi sampai ukurnny maka akan di transformasi
        if (transform.position.x  < -backgroundLength*2f)
        {
            RecyleBackground();
            Debug.Log("transisi x : "+transform.position.x);
        }

	}
    //method
    private void RecyleBackground()
    {
        Vector2 offset = new Vector2(backgroundLength * 4f, 0);
        transform.position =  ((Vector2)transform.position) + offset;
    }
}
