using UnityEngine;
using System.Collections;
using UnityEditor;
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
			moveForward();
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			moveBackward();
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
			if( anglenow > -10 )
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


		checkHealth ();
	}

	public void moveForward(){
		gameObject.transform.Translate(gameObject.transform.forward*Time.deltaTime*5, Space.World);

	}

	public void moveBackward(){
		gameObject.transform.Translate(gameObject.transform.forward*Time.deltaTime*-5, Space.World);
	}

	void checkHealth(){
		if (healthPoint <= 0.0f) {
			Destroy (gameObject);
			controller.tankExploded(transform.position);
		}
	}

	public void attacked(){
		healthPoint -= 10;
	}
}
