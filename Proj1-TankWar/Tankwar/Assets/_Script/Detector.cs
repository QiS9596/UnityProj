using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour {
	public GameObject fatherGameobject;
	Enemy father;

	// Use this for initialization
	void Start () {
		father = fatherGameobject.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other){
		if (other.tag == Tags.Player) {
			father.aim = other.transform.position;
			father.noticing = true;
		}
	}
}
