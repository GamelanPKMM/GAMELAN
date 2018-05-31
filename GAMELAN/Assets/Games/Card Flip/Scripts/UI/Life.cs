using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour 
{
	public static Life control;
	public GameObject[] lives;

	private int remaining;

	void Start ()
	{
		if (control == null)
		{
			control = this;
		}
		else
		{
			Destroy (this.gameObject);
		}

		remaining = lives.Length;
	}

	//
	// Increase life by one
	//
	public void IncreaseLife ()
	{
		if (remaining < lives.Length)
		{
			lives [remaining].SetActive (true);
			remaining += 1;
		}
	}

	//
	// Decrease life by one
	//
	public void DecreaseLife ()
	{
		if (remaining > 0)
		{
			lives [remaining - 1].SetActive (false);
			remaining -= 1;
		}

		if (remaining == 0)
		{
			CardFlipManager.control.GameOver ();
		}
	}

	//
	//
	// Properties
	//
	//
	public int Remaining {
		get { return this.remaining; }
	}
}
