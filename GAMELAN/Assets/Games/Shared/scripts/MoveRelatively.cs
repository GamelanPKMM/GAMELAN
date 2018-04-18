using UnityEngine;
using System.Collections;

public class MoveRelatively : MonoBehaviour
{
    public float speedMultiplier = 1;
    public float speedOffset = 0;
    private float actualSpeedOffset;

    void Start()
    {
        actualSpeedOffset = Random.value < 0.5 ? speedOffset : -speedOffset;
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * (speedMultiplier + actualSpeedOffset);
    }
}
