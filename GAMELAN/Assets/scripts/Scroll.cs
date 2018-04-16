using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    public float speed = 0.5f;

    // Update is called once per frame
    void Update () {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x += Time.deltaTime;
        mat.mainTextureOffset = offset;
	}
}
