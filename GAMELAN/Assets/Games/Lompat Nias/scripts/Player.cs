using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player instance;
    public float up = 400f;
    public float down = 100f;
    public Collider2D ground;
    public Collider2D obs;
    private bool life = false;
    private Rigidbody2D rgbd;
    private Animator anim;
    private bool jumpLock = true;
    public AudioSource audio;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Flap");
    }

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
    // Update is called once per frame
    void Update () {
        if (life == false && GameControl.instance.input && !DelayStart.self.DelayLock)
        {
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))&& jumpLock && GameControl.instance.stopBird == false)
            {
                anim.SetTrigger("Flap");
                rgbd.velocity = Vector2.zero;
                rgbd.AddForce(new Vector2(0,up));
                jumpLock = false;
                audio.PlayOneShot(PlayerSound.self.jump,0.6f);
            }
            if (Input.GetKey(KeyCode.DownArrow)&& !jumpLock && GameControl.instance.stopBird == false)
            {
                rgbd.AddForce(new Vector2(0, -down));
            }
            if (Input.GetKeyDown(KeyCode.Escape) && GameControl.instance.stopBird == false)
            {
                GameControl.instance.birdPause();
            }
        }
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        //fungsi untuk mengecek nyawa
        if (GameControl.instance.life == 0)
        {
            anim.SetTrigger("Die");
            life = false;
            //Debug.Log("Dead");
            GameControl.instance.birdDead();        
        }
        if (other.gameObject.name == "BatuNias(Clone)")
        {
            if (jumpLock)
            {
                anim.SetTrigger("Flash");
            }
            else
            {
                anim.SetTrigger("FlashFlap");
            }
        }
        if (other.gameObject.name == "Soal(Clone)")
        {
            audio.PlayOneShot(PlayerSound.self.earncoin, 0.6f);
        }
        //fungsi unutk mentriger jumplock
        if (other.gameObject.name == "Ground")
        {
            jumpLock = true;
            anim.SetTrigger("Idle");
            //Debug.Log("idle");
        }
    }
    public void correctSound()
    {
        audio.PlayOneShot(PlayerSound.self.earnStar, 0.6f);
    }
}