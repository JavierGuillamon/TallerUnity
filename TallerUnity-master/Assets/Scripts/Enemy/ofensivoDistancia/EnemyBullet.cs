using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
    public float speed;
    Vector2 direction;
    bool isReady;

	// Use this for initialization
	void Start () {
	
	}
	void awake()
    {
        isReady = false;
    }
    public void setDirection(Vector2 _direction)
    {
        direction = _direction.normalized;
        isReady = true;
    }

	// Update is called once per frame
	void Update () {
	    if (isReady){
            Vector2 position = transform.position;
            position += direction * speed *Time.deltaTime;
            transform.position = position;
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
