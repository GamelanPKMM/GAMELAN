using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour {
	public static TimeBar control;
	public Image progressBarImage;
	public int duration;
    private float timeFinish = 0;


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
		
        if (!CardFlipManager.control.stop)
        {
            progressBarImage.fillAmount = timeFinish / this.duration;
            timeFinish += Time.deltaTime;
        }
        
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
