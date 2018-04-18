using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanPlayerHit : KarapanSubScontroller {
    private float lastBlink = 0;
    private float deltablink = 0.1F;
    private const float godFrameDur = 2F;
    private bool isGodFrame = false;
    private float godFrameStart = 0;
    private bool b = false;
    public Sprite sprite;
    private SpriteRenderer sr;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isGodFrame  && gameControl.getGameState()&& other.gameObject.CompareTag("Enemy"))
        {   
            Debug.Log("PlayerHit");
            gameControl.lifeControl.decreaseLife();
            isGodFrame = true;
            godFrameStart = Time.time;
            blink();
        }
    }
    protected override void start()
    {
        base.start();
        sr = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        sprite = sr.sprite;
    }
    void Update()
    {
        blink();
    }
    void FixedUpdate()
    {
        godFrameCheck();
    }
    void blink()
    {
        float dt = Time.time - lastBlink;
        if (isGodFrame)
        {
            if (dt >= deltablink)
            {
                sr.enabled = b;
                b = !b;
                lastBlink = Time.time;
            }
        }

    }

    void godFrameCheck()
    {
        if (isGodFrame)
        {
            if (Time.time - godFrameStart > godFrameDur)
            {
                isGodFrame = false;
                sr.enabled = true;
                b = false;
            }
        }
    }
}
