using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanLifeUIControl : KarapanSubScontroller {
    private GameObject[] LiveSprites;
    public GameObject LiveContainer;
    public GameObject LivePrefab;
    public float lifeDist =     40;
    public float initialLivePos = -50;
    protected override void start()
    {
        base.start();
        drawLife();
        gameControl.addEvent("LifeDecrease", drawRemLive);
        gameControl.addEvent("LifeIncrease", drawRemLive);
        gameControl.addEvent("Reset", drawRemLive);
        LivePrefab.SetActive(false);

    }
    void drawRemLive()
    {
        foreach (GameObject g in LiveSprites)
        {
            g.SetActive(false);
        }
        for (int i = 0; i < gameControl.lifeControl.getLife(); i++)
        {
            LiveSprites[i].SetActive(true);
        }
    }
    void drawLife()
    {
        LiveSprites = new GameObject[gameControl.lifeControl.maxLifeCap];
        for (int i = 0; i < LiveSprites.Length; i++)
        {
            LiveSprites[i] = Instantiate(LivePrefab);
            LiveSprites[i].transform.SetParent(LiveContainer.transform);
            LiveSprites[i].transform.localScale = new Vector3(1, 1, 0);
            LiveSprites[i].transform.localPosition = new Vector3((float)(initialLivePos + (i) * lifeDist), (float)-0.15, 0);
            LiveSprites[i].SetActive(true);
        }
    }
}
