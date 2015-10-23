using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float rotateSpeed = 1.0f;
	public float refuelTime = 3.0f;
	public GameObject bullet;
	private float timer = 0.0f;
	private float healthPoint = 100.0f;
	private GameObject head;
	private GameObject emitter;
	private int anglenow = 0;
	private GameController controller;

	// Use this for initialization
	void Start () {
		head = GameObject.Find ("tank_top");
		emitter = GameObject.Find ("M60cann");
		controller = GameObject.FindWithTag (Tags.GameController).GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		/*moving forward and backward*/
		gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3(0,-10,0));
		if (Input.GetKey (KeyCode.UpArrow) ) {
			gameObject.transform.Translate(gameObject.transform.forward*Time.deltaTime*5, Space.World);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.transform.Translate(gameObject.transform.forward*Time.deltaTime*-5, Space.World);
		}
		/*rotate the whole tank*/
		float h = Input.GetAxis ("Horizontal");
		transform.Rotate(0, h * rotateSpeed, 0);

		if ( Input.GetButton("Fire1"))
			head.transform.Rotate(new Vector3(0,-1,0), 1);
		if ( Input.GetButton("Fire2"))
			head.transform.Rotate(new Vector3(0,1,0), 1);

		if ( Input.GetButton("Jump") )
		{
			if( anglenow < 20 )
			{
				emitter.transform.Rotate(new Vector3(0,1,0), 1);
				anglenow++;
			}
		}
		if ( Input.GetButton("Submit") )
		{
			if( anglenow > 0 )
			{
				emitter.transform.Rotate(new Vector3(0,-1,0), 1);
				anglenow--;
			}
		}

		if (Input.GetButton ("Fire3") && timer >= refuelTime) {
			GameObject newBullet = (GameObject)Instantiate(bullet);
			newBullet.transform.position = emitter.transform.position+emitter.transform.right*2;
			newBullet.GetComponent<Rigidbody>().AddForce(emitter.transform.right*1000);
			timer = 0.0f;
		}
		timer += Time.deltaTime;

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
	public void attacked(){
		healthPoint -= 10;
	}
}
