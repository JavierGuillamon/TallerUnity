using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
    public float speed;
    Vector2 direction;
    bool isReady;

	// Use this for initialization
	void Start () {
        if (direction.x ==1) transform.Rotate(0, 0, 0);
        else if(direction.x==-1) transform.Rotate(0, 0, -180);
        if (direction.y==1) transform.Rotate(0, 0,90 );
        else if(direction.y==-1)transform.Rotate(0, 0, -90);
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
