using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 60.0f;
	public float backwordSpeed = -10.0f;
	public float smooth = 0.5f;
	public float rotateSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow)) {
			gameObject.GetComponent<Rigidbody>().AddForce(transform.right * speed);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.GetComponent<Rigidbody>().AddForce(transform.right * speed * -1.0f);
		}

		float h = Input.GetAxis ("Horizontal");
		transform.Rotate(0, h * rotateSpeed, 0);

	}
}
