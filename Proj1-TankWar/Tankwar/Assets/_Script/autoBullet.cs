using UnityEngine;
using System.Collections;

public class autoBullet : MonoBehaviour {
	public Vector3 orientation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (orientation * 100.0f * Time.deltaTime);
	}
}
