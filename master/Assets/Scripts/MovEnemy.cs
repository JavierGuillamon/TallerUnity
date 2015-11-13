using UnityEngine;
using System.Collections;

public class MovEnemy : MonoBehaviour {

	public Vector3 t1;
	public Vector3 t2;
	public float speed;
	public GameObject enemy;
	
	private bool movA = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (movA) {
			enemy.transform.position = Vector3.Lerp (enemy.transform.position, t2, speed);
		} else {
			enemy.transform.position = Vector3.Lerp (enemy.transform.position, t1, speed);
		}
		if (enemy.transform.position == t1) {
			movA = true;
		} else if (enemy.transform.position == t2) {
			movA = false;
		}
	}


}
