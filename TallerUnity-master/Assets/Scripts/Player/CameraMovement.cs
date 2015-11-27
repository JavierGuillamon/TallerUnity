using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform Target;

	//public Vector2 Margin;
	public BoxCollider2D Bounds;

	public float m_speed = 0.1f;
	private Camera cam;

	private Vector3 _min,_max;

	public bool IsFollowing{ get;set;}

	// Use this for initialization
	void Start () {

		cam = GetComponent<Camera> ();

		_max = Bounds.bounds.max;
		_min = Bounds.bounds.min;
		IsFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		var x = transform.position.x;
		var y = transform.position.y;

		cam.orthographicSize = (Screen.height / 100f) / 4f;

		if (Target) {
			//transform.position = Vector3.Lerp(transform.position, Target.position, m_speed)+new Vector3(0,0,-10);
			x = Mathf.Lerp (x,Target.position.x,m_speed);
			y = Mathf.Lerp(y,Target.position.y,m_speed);
		
		}
		/*
		if (IsFollowing) {
			if(Mathf.Abs (x - Target.position.x) > Margin.x)
				x = Mathf.Lerp (x,Target.position.x, Smoothing.x * Time.deltaTime); 
			if(Mathf.Abs (y-Target.position.y)>Margin.y)
				y = Mathf.Lerp(y,Target.position.y, Smoothing.y * Time.deltaTime);
		}*/

		var cameraHalfWidth = cam.orthographicSize * ((float)Screen.width / Screen.height);

		x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, _min.y + cam.orthographicSize, _max.y - cam.orthographicSize);

		transform.position = new Vector3 (x, y, transform.position.z);

	}
}
