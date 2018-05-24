using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanStarControl : StarController {
    public GameObject StarPrefab;
    public Vector3 StartPos = new Vector3(0, 10, 0);
    public ProgressControl progressControl;
    public int spawnDelta = 20;
    public int lastSpawn = 0;
    protected override void start()
    {
        base.start();
        StarPrefab = GameObject.FindGameObjectWithTag("Star");
        progressControl = basicGameControl.SubController<ProgressControl>("ProgressControl");
        StarPrefab.SetActive(false);
        basicGameControl.addEvent("Reset", reset);
    }

    void spawnStar()
    {
        if (basicGameControl.getGameState() && !basicGameControl.isPause() && base.starCount < maksStar)
        {
                GameObject star = (GameObject)Instantiate(StarPrefab);
                star.transform.position = new Vector3(Random.Range(-2, 3) * 2.5F, StartPos.y, 0);
                star.SetActive(true);
                star.transform.SetParent(gameObject.transform);
        }
    }
    void FixedUpdate()
    {
        if (basicGameControl.getGameState() && !basicGameControl.isPause())
        {
            if (progressControl.progress >= lastSpawn + spawnDelta)
            {
                spawnStar();
                Debug.Log("Spwning Star");
                lastSpawn = (int)progressControl.progress;
            }
        }
    }

    void reset() {
        lastSpawn = 0;
    }
  
}
