using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public static Bird instance;
    public float up = 400f;
    public Collider2D ground;
    public Collider2D obs;
    private bool life = false;
    private Rigidbody2D rgbd;
    private Animator anim;
    private bool jumpLock = true;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Flap");
    }
	
	// Update is called once per frame
	void Update () {
        if (life == false)
        {
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))&& jumpLock)
            {
                anim.SetTrigger("Flap");
                rgbd.velocity = Vector2.zero;
                rgbd.AddForce(new Vector2(0,up));
                jumpLock = false;
                Debug.Log("Flap");
            }
            if (Input.GetKey(KeyCode.DownArrow)&& !jumpLock){
                rgbd.AddForce(new Vector2(0, -100));
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameControl.instance.birdPause();
            }
        }
	}

    public void OnTriggerEnter2D(Collider2D batu)
    {
        //fungsi untuk mengecek nyawa
        if (GameControl.instance.life == 0)
        {
            anim.SetTrigger("Die");
            life = false;
            //Debug.Log("Dead");
            GameControl.instance.birdDead();        
        }
        if (batu == obs)
        {
            anim.SetTrigger("Flash");
            anim.SetTrigger("Idle");
            Debug.Log("Flash");
        }
        //fungsi unutk mentriger jumplock
        if (batu == ground)
        {
            jumpLock = true;
            anim.SetTrigger("Idle");
            Debug.Log("idle");
        }
    }
}
