using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCloudMove : MonoBehaviour
{
    public Rigidbody2D cloud;
    public float speed;
    public float maxMove;
    private float time;
    private bool flip = false;
    private void Start()
    {
        cloud.velocity = new Vector2(speed,0);
    }
    void Update()
    {
        time += Time.deltaTime;
        if (maxMove < time)
        {
            time = 0;
            if (flip == false)
            {
                flip = true;
                cloud.velocity = new Vector2(-speed, 0);
            }
            else
            {
                flip = false;
                cloud.velocity = new Vector2(speed, 0);
            }
            
        }
    }
}
 
