using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour 
{
	public static Star control;
	public GameObject[] stars;
	public int obtainedStar = 0;

	void Start () 
	{
		if(control == null)
		{
			control = this;
		}
		else{
			Destroy (this.gameObject);
		}
	}

	//
	// Increase star by one
	//
	public void AddStar ()
	{
		if(obtainedStar < stars.Length)
		{
			stars [obtainedStar].SetActive (true);
			obtainedStar += 1;
		}
	}
}
