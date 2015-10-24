using UnityEngine;
using System.Collections;

public class EnemyTankObject : MonoBehaviour {
	public GameObject father;
	private Enemy enemy;
	// Use this for initialization
	void Start () {
		enemy = father.GetComponent<Enemy> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void attacked(){
		enemy.attacked();
	}
}
