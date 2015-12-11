using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {
    public Vector2 speed;
    public Rigidbody2D rb;
    //Vector2 velocity;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity += speed;
       
    }
	
	void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
