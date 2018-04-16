using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public float up = 400f;
    public Collider2D ground;
    public Collider2D obs;
    private bool life = false;
    private Rigidbody2D rgbd;
    private Animator anim;
    private bool jumpLock = true;
    // Use this for initialization
    void Start () {
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (life == false)
        {
            if ((Input.GetKey("up") || Input.GetKeyDown("space"))&& jumpLock)
            {
                anim.SetTrigger("Flap");
                rgbd.velocity = Vector2.zero;
                rgbd.AddForce(new Vector2(0,up));
                jumpLock = false;
            }
            if (Input.GetKey("down")&& !jumpLock){
                rgbd.AddForce(new Vector2(0, -100));
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D batu)
    {
        //fungsi untuk mengecek nyawa
        if (GameControl.instance.life == 0)
        {
            anim.SetTrigger("Die");
            life = false;
            Debug.Log("Dead");
            GameControl.instance.birdDead();
        }
        if (batu == obs)
        {
            anim.SetTrigger("Flash");
            anim.SetTrigger("Idle");
        }
        //fungsi unutk mentriger jumplock
        if (batu == ground)
        {
            jumpLock = true;
            anim.SetTrigger("Idle");
        }
    }
}
