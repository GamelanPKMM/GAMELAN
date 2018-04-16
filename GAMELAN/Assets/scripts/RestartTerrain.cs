using UnityEngine;
using System.Collections;

public class RestartTerrain : MonoBehaviour {
	public new SpriteRenderer renderer;
	public int terrainOffset = 0;
    public int speed = 2;

	void Start () {
		transform.position += terrainOffset * renderer.bounds.size.x * Vector3.right;
	}
	
	void Update () {
		if (transform.position.x > -renderer.bounds.size.x) {
			return;
		}
		transform.position += speed * renderer.bounds.size.x * Vector3.right;
	}
}
