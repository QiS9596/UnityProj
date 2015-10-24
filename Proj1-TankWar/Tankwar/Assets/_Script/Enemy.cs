using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float healthPoint = 50.0f;
	public GameObject bullet;
	public Vector3 aim;
	public bool noticing;
	private RaycastHit hit;
	public GameObject children;
	public GameObject emitter;
	public float cooldown = 4.0f;
	private float cooldownCount = 0.0f;
	// Use this for initialization
	void Start () {
		noticing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (noticing) {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(aim - transform.position), 1.0f * Time.deltaTime);
			if(Physics.Raycast(transform.position, transform.forward, out hit, 40.0f)){
				if(hit.collider.tag == Tags.Player){
					Debug.Log ("Successfully found player");
					if(cooldownCount >= cooldown){
						Debug.Log ("Ready to fire");
						GameObject newBullet = (GameObject)Instantiate(bullet);
						newBullet.transform.position = transform.position + transform.up*1 + transform.forward * 2;
						newBullet.GetComponent<autoBullet>().orientation = transform.forward;
						cooldownCount = 0.0f;
					}
				}
			}
			cooldownCount += Time.deltaTime;
		}
	}

	public void attacked(){

	}
}
