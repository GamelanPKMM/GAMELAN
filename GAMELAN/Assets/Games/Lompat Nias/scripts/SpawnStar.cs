using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour {
    public static SpawnStar self;
    public GameObject prefabs;
    private GameObject ColumnPrefabs;
    public float spawnRateResult = 15f;
    public int maxSpawn = 5;
    public float YSpawnLocation = -1.5f;
    public float minX;
    public float maxX;
    public bool starLock = false;
    private float time;
    private int currentColumn;
    //setting spawn obs.
    private Vector2 objectPosition = new Vector2(-16f, -1.5f);

    private void Awake()
    {
        if (self == null)
        {
            self = this;
        }
        else if (self != this)
        {
            Destroy(gameObject);
        }
    }

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
            time = 0;
            starLock = true;
            currentColumn++;
        }
    }

    //fungsi untuk menambah star
    public void AddStar(float x)
    {
        ColumnPrefabs = (GameObject)Instantiate(prefabs, objectPosition, Quaternion.identity);
        ColumnPrefabs.transform.position = new Vector2(x, YSpawnLocation);
    }
}
