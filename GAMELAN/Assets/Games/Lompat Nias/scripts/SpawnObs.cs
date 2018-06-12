using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObs : MonoBehaviour {
    public int sizeColumn = 5;
    public GameObject prefabs;
    private GameObject[] ColumnPrefabs;
    public float spawnRate = 4f;
    public float minX;
    public float maxX;
    public float positionY = -3.7f;
    private float time;
    private int currentColumn;
    //setting spawn obs.
    private Vector2 objectPosition = new Vector2(-16f, -23.7f);

    // Use this for initialization
    void Start () {
        currentColumn = 0;
        time = 0;
        ColumnPrefabs = new GameObject[sizeColumn];
        for (int i = 0; i < sizeColumn; i++)
        {
            ColumnPrefabs[i] = (GameObject)Instantiate(prefabs, objectPosition, Quaternion.identity );
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        //untuk memindah batu jika batu sudah melebihi dari yang ditentukan
        if (GameControl.instance.gameOver == false && time >= spawnRate && GameControl.instance.stopBird == false)
        {
            time = 0;
            float spawnXPosition = Random.Range(minX, maxX);
            //Debug.Log(currentColumn);
            ColumnPrefabs[currentColumn].transform.position = new Vector2(spawnXPosition, positionY);
            //Menambah bintang di atas batu
            if (SpawnStar.self.starLock)
            {
                SpawnStar.self.AddStar(spawnXPosition);
                SpawnStar.self.starLock = false;
            }
            currentColumn++;
            //untuk mereset currentColumn
            if (currentColumn >= sizeColumn)
            {
                currentColumn = 0;
            }
        }

		
	}
}
