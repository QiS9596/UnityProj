using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float healthPoint;
	public GameObject bullet;
	private Vector3 aim;
	private bool noticing;
	private RaycastHit hit;
	// Use this for initialization
	void Start () {
		noticing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (transform.position, aim, out hit, 50.0f)) {
			if(hit.collider.gameObject.tag == Tags.Player)
			transform.rotation = Quaternion.Lerp (transform.rotation, hit.transform.rotation, Time.deltaTime);
		}
	}
	void OnTriggerStay(Collider other){
		if (other.tag == Tags.Player) {
			aim = other.transform.position;
			noticing = true;
		}
	}
	public void attacked(){

	}
}
