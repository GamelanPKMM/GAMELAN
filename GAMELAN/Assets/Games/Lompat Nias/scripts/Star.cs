using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    public GameObject star;
    private Rigidbody2D rgbd;

    private void Start()
    {
        rgbd = star.GetComponent<Rigidbody2D>();
        rgbd.velocity = new Vector2(-GameControl.instance.scrollSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            GameControl.instance.lifeIncrease();
            //masih percobaan
            GameControl.instance.star += 1;
            lifeControlUI.instance.UpdateLife();
            StarControl.instance.UpdateStar();
            Debug.Log("Bintang");
            Destroy(gameObject);
            GameControl.instance.birdPause();
        }
    }

    private void Update()
    {
        if (GameControl.instance.gameOver == true)
        {
            rgbd.velocity = Vector2.zero;
        }
        else if (GameControl.instance.result % 5 == 0 && GameControl.instance.gameOver == false)
        {
            rgbd.velocity = new Vector2(-GameControl.instance.scrollSpeed, 0);
        }

    }
}
