using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    public GameObject[] obstacles;
    public float mainSpeed = 10;
    public float maxSpeed = 10;
    public float acceleration = 10;

    void Start()
    {
    }

    void Update()
    {
        if (mainSpeed < maxSpeed)
        {
            mainSpeed += acceleration;
        }
    }
}
