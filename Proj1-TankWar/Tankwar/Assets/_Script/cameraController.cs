using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {
	public Camera[] cameras;
	public Camera mainCamera;
	public float cooldown = 1.0f;
	float cooldownCount = 0.0f;
	int index;
	// Use this for initialization
	void Start () {
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		mainCamera.transform.position = cameras [index].transform.position;
		mainCamera.transform.rotation = cameras [index].transform.rotation;
		if (Input.GetKey (KeyCode.C)&&cooldownCount >= cooldown) {
			changeView ();
			cooldownCount = 0.0f;
		}
		cooldownCount += Time.deltaTime;
	}

	void changeView(){
		index = (index == 0 ? 1 : 0);
	}
}
