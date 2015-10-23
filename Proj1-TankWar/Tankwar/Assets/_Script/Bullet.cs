using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private GameController controller;

	void OnTriggerEnter(Collider other){
	

		switch (other.tag) {

		case Tags.Enemy:
			other.gameObject.GetComponent<Enemy>().attacked();
			controller.exploded (gameObject.transform.position);
			Destroy(gameObject);
			break;
		case Tags.Player:
			other.gameObject.GetComponent<PlayerController>().attacked();
			controller.exploded (gameObject.transform.position);
			Destroy(gameObject);
			break;
		case Tags.Environment:
			controller.exploded(gameObject.transform.position);
			Destroy(gameObject);
			break;
		}

	}
	// Use this for initialization
	void Start () {
		controller = GameObject.FindWithTag (Tags.GameController).GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
