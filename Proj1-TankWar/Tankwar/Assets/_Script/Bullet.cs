using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject Explosion;
	public AudioClip sExplosion;
	public Material material;


	void OnTriggerEnter(Collider other){
		Destroy (this.gameObject);
		GameObject NewExplosion = (GameObject)Instantiate (Explosion, transform.position, Quaternion.identity);
//		switch (other.tag) {
//
//		case Tags.Enemy:
//			other.gameObject.GetComponent<Enemy>().attacked();
//			break;
//		case Tags.Player:
//			other.gameObject.GetComponent<Player>().attacked();
//			break;
//		}
	}
	// Use this for initialization
	void Start () {
//		TagManager = new Tags();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
