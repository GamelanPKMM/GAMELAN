using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanEnemyControl : KarapanSubScontroller {
    private int maxEnemPerKloter = 4;
    public float baseEnemSpawnDelta = 2F;
    public float spawnDeltaVariable;
    private GameObject[] PrefabEnem = new GameObject[4];
    private Vector3 StartPos = new Vector3(0, 10, 0);
    private float lastSpawn;
    protected override void start()
    {
        base.start();
        for (int i = 0; i < PrefabEnem.Length; i++)
        {
            PrefabEnem[i] = GameObject.Find("Enemy" + (i + 1));
        }
        lastSpawn = Time.time;
        gameControl.addEvent("Reset", reset);
    }

    void FixedUpdate()
    {
        if (gameControl.getGameState() && !gameControl.isPause())
        {
            if (Time.time - lastSpawn > baseEnemSpawnDelta - (gameControl.progressControl.progress / gameControl.progressControl.endCap) * 0.75F + spawnDeltaVariable)
            {
                SpawnEnem();
                Debug.Log("Spwning enem");
                lastSpawn = Time.time;
            }
        } else lastSpawn+= Time.fixedDeltaTime;
	}

    void SpawnEnem() {
        if (gameControl.getGameState() && !gameControl.isPause())
        {
            int num = Random.Range(1, maxEnemPerKloter);
            while (num > 0)
            {
                GameObject enem = (GameObject)Instantiate(PrefabEnem[Random.Range(0, PrefabEnem.Length - 1)]);
                enem.transform.position = new Vector3(Random.Range(-2, 3) * 2.5F, StartPos.y, 0);
                enem.GetComponent<KarapanEnemyInstanceControl>().isAffected = true;
                enem.transform.parent = gameObject.transform;
                enem.name = "enemy";
                num--;
            }
            spawnDeltaVariable = Random.Range(1, 100) / 100F * baseEnemSpawnDelta / 2 * Random.Range(-1F, 0.5F) * (((float)(gameControl.progressControl.progress))/gameControl.progressControl.endCap);
        }
    }


    void reset() {
        maxEnemPerKloter = 4;
        baseEnemSpawnDelta = 2F;
        spawnDeltaVariable = 0;
        lastSpawn = Time.time;
    }
}
