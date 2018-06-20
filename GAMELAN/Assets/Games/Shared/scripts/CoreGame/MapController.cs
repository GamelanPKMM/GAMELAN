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
        if (main != null)
        {
            if (!main.isPlaying)
            {
                main.Play();
            }
        }
        else {
            AudioSource audio = AudioController.getInstance().registerSound("Audio/Intro insyaAllah fix", "MainMenu");
            DontDestroyOnLoad(audio);
            audio.loop = true;
            audio.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
