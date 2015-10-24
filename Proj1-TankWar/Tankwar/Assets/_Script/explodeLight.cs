using UnityEngine;
using System.Collections;

public class explodeLight : MonoBehaviour {
	Light light;
	public float maxIntensity = 30.0f;
	public float smooth = 1.0f;
	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
		light.intensity = maxIntensity;
	}
	
	// Update is called once per frame
	void Update () {
		if (light.intensity > 0) {
			light.intensity -= Time.deltaTime * smooth;
		}
	}
}
