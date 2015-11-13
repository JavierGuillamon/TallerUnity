using UnityEngine;
using System.Collections;

public class FixRotation : MonoBehaviour {
    Quaternion rotation;
	// Use this for initialization
	void Start () {
        rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = rotation;
	}
}
