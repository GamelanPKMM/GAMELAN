using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
    public CloudSceneChanger self;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        self.moveOut();
        AudioSource main = AudioController.getInstance().getAudioSource("MainMenu");
        if (!main.isPlaying)
        {
            main.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
