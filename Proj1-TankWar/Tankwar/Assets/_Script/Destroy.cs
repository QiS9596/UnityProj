using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	public int waitSeconds = 1;
	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (waitSeconds);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
