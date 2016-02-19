using UnityEngine;
using System.Collections;

public class ShieldControl : MonoBehaviour {

	public GameObject shield;
	private SpriteRenderer rend; 
	private CircleCollider2D coll;
	private bool shieldUp = false;
	//private float auxTimer;
	// Use this for initialization
	void Start () {

		rend = shield.GetComponent<SpriteRenderer> ();
		coll = shield.GetComponent<CircleCollider2D> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			activateShield (shieldUp);
		}
		if (Input.GetMouseButtonUp (0)) {
			clickUp (shieldUp);
		}

	}

	void activateShield(bool tru){
		if (tru) {
			rend.enabled = false;
			coll.enabled = false;
		} else {
			rend.enabled = true; 
			coll.enabled = true;
		}
	}
	void clickUp(bool tru){
		if (tru)
			shieldUp = false;
		else
			shieldUp = true;
	}
}
