using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject explosion;
	public GameObject tankExplode;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void exploded(Vector3 otherPosition){
		Instantiate (explosion, otherPosition, Quaternion.identity);
	}
}
