using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
    public CloudSceneChanger self;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        self.moveOut();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
