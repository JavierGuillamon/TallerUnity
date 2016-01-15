using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {
    public Vector2 speed;
    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity += speed;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);      
    }

    public void setSpeed(Vector2 v2)
    {
        speed = v2;
    }
}
