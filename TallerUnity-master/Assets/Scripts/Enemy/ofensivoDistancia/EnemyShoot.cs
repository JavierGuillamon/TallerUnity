using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
    public GameObject bulletGO;
    public Vector2 direction;

    private float nextActionTime = 0.0f;
    public float period = 1f;
    // Use this for initialization
    void Start ()
    {
    }

	// Update is called once per frame
	void Update ()
    {
        if (Time.time > nextActionTime)
        {
            StartCoroutine(fire(period));
        }
    }
   
    IEnumerator fire(float x)
    {
        nextActionTime = Time.time + x;
        GameObject bullet = (GameObject)Instantiate(bulletGO);
        bullet.transform.position = transform.position;
        bullet.GetComponent<EnemyBullet>().setDirection(direction);
        yield return new WaitForSeconds(1f);
    }

}
