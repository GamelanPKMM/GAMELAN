using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batu : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            GameControl.instance.life -= 1;
            GameControl.instance.lifeDecrease();
            //Debug.Log("Nyawa : "+GameControl.instance.life);
        }
    }
}
