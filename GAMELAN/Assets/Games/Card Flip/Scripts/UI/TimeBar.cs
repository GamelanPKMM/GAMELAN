using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour {
	public static TimeBar control;
	public Image progressBarImage;
	public int duration;

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

        progressBarImage.type = Image.Type.Filled;
        progressBarImage.fillMethod = Image.FillMethod.Horizontal;
        progressBarImage.fillAmount = 0.5f;
	}

	void Update ()
	{
		progressBarImage.fillAmount = Time.time / this.duration;

		if (progressBarImage.fillAmount == 1)
		{
			CardFlipManager.control.GameOver ();
		}
	}

	public void AddTime (float time)
	{
		progressBarImage.fillAmount += time / this.duration;
	}
}
