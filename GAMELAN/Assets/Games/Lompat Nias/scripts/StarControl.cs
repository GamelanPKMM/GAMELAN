using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarControl : MonoBehaviour {
    public GameObject [] StarImage;
    public static StarControl instance;
    private byte value = 0 ;

	// Use this for initialization
	private void Start () {
        value = 0;
        if (StarImage != null)
        {
            for (int i = 0; i < StarImage.Length; i++)
            {
                StarImage[i].SetActive(false);
            }
        }        
	}

    public void tambahBintang()
    {
        if (value <= StarImage.Length && value >= 0)
        {
            StarImage[value].SetActive(true);
            value += 1;
        }
    }


    public void kurangBintang()
    {
        if (value <= StarImage.Length && value >= 0)
        {
            StarImage[value].SetActive(false);
            value -= 1;
        }
    }
}
