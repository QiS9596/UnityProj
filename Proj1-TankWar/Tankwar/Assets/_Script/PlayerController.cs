using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 60.0f;
	public float backwordSpeed = -10.0f;
	public float smooth = 0.5f;
	public float rotateSpeed = 1.0f;
	public float forwardSpeedMax = 20.0f;
	public float backwardSpeedMax = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*moving forward and backward*/
		gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3(0,-10,0));
		if (Input.GetKey (KeyCode.UpArrow) ) {
			gameObject.GetComponent<Rigidbody>().velocity = transform.right * speed;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.GetComponent<Rigidbody>().AddForce(transform.right * speed * -1.0f);
		}
		/*rotate the whole tank*/
		float h = Input.GetAxis ("Horizontal");
		transform.Rotate(0, h * rotateSpeed, 0);


	}

	void ButtonDebugTest(){
		if (Input.GetButton ("Fire1")) {
			Debug.Log("Fire1");
		}
		if (Input.GetButton ("Fire2"))
			Debug.Log ("Fire2");
		if (Input.GetButton ("Fire3"))
			Debug.Log ("Fire3");
		if (Input.GetButton ("Jump"))
			Debug.Log ("Jump");
		if (Input.GetButton ("Submit"))
			Debug.Log ("Submit");
	}
}
