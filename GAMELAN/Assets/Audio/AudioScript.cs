using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClip : MonoBehaviour {

    AudioSource myAudio;
	// Use this for initialization
	void Start () {

        myAudio = GetComponent<AudioSource>();
        myAudio.Play();
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
