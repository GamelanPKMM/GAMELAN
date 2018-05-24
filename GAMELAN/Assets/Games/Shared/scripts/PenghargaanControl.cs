using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenghargaanControl : MonoBehaviour {

    public GameObject penghargaanContainer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void open() {
        penghargaanContainer.SetActive(true);
    }

    public void close() {
        penghargaanContainer.SetActive(false);
    }
}
