using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour {
    public GameObject prefabs;
    private GameObject ColumnPrefabs;
    public float spawnRateResult = 15f;
    public int maxSpawn = 5;
    public float YSpawnLocation = -1.5f;
    public float minX;
    public float maxX;
    private float time;
    private int currentColumn;
    //setting spawn obs.
    private Vector2 objectPosition = new Vector2(-16f, -1.5f);

    // Use this for initialization
    void Start()
    {
        currentColumn = 0;
        time = 0;
            ColumnPrefabs = (GameObject)Instantiate(prefabs, objectPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (GameControl.instance.gameOver == false && time >= spawnRateResult && currentColumn < maxSpawn)
        {
            ColumnPrefabs = (GameObject)Instantiate(prefabs, objectPosition, Quaternion.identity);
            time = 0;
            float spawnXPosition = Random.Range(minX, maxX);
            ColumnPrefabs.transform.position = new Vector2(spawnXPosition, YSpawnLocation);
            currentColumn++;
        }


    }
}
