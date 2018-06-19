using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanEnemyControl : KarapanSubScontroller {
    private int maxEnemPerKloter = 4;
    public float baseEnemSpawnDelta = 2F;
    public float spawnDeltaVariable;
    public GameObject[] PrefabEnem = new GameObject[4];
    public Vector3 StartPos = new Vector3(0, 10, 0);
    public float lastSpawn;
    bool starSpawn = false;
    protected override void start()
    {
        base.start();
        for (int i = 0; i < PrefabEnem.Length; i++)
        {
            PrefabEnem[i] = GameObject.Find("Enemy" + (i + 1));
        }
        lastSpawn = Time.time;
        gameControl.addEvent("Reset", reset);
        gameControl.addEvent("StarSpawn", spawnStar);
        UserInputControl input = basicGameControl.SubController<UserInputControl>("UserInputControl");
        input.addKeyMap(new KeyMap(new KeyCode[] { KeyCode.M }, "SpawnStar", () => { spawnStar(); }, Input.GetKeyDown, UserInputControl.SeldomtimePress));

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
            bool[] pos = new bool[5];
            while (num > 0)
            {
                GameObject enem = (GameObject)Instantiate(PrefabEnem[Random.Range(0, PrefabEnem.Length - 1)]);
                int posi = -100;
                do { posi = Random.Range(-2, 3); } while (pos[posi+2]);
                pos[posi + 2] = true;
                enem.transform.position = new Vector3(posi * 2.5F, StartPos.y, 0);
                enem.GetComponent<KarapanEnemyInstanceControl>().isAffected = true;
                enem.transform.parent = gameObject.transform;
                enem.name = "enemy";
                num--;
            }
            if (starSpawn) {
                for (int i = 0; i < pos.Length; i++) {
                    if (!pos[i]) {
                        basicGameControl.SubController<KarapanStarControl>("KarapanStarControl").spawnStar(i-2);
                        starSpawn = false;
                        break;
                    }
                }
            }
            spawnDeltaVariable = Random.Range(1, 100) / 100F * baseEnemSpawnDelta / 2 * Random.Range(-1F, 0.5F) * (((float)(gameControl.progressControl.progress))/gameControl.progressControl.endCap);
        }
    }

    void spawnStar() {
        starSpawn = true;
    }
    void reset() {
        maxEnemPerKloter = 4;
        spawnDeltaVariable = 0;
        lastSpawn = Time.time;
    }
}
