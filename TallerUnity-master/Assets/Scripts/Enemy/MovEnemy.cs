using UnityEngine;
using System.Collections;

public class MovEnemy : MonoBehaviour {

    public Transform tr;
    public Animator anim;
    public Rigidbody2D body;
    public float speed = 1;
    float RandX, RandY;
    bool mov = false;
    float scaleRangeMin = 0.8f;
    float scaleRangeMax = 1.2f;

    void Start()
    {
        tr = GetComponent<Transform>();
        float scale = Random.Range(scaleRangeMin, scaleRangeMax);
        tr.localScale *= scale;
        speed *= scale;
        anim.speed *= scale;
    }

	// Update is called once per frame
	void Update () {
        if(!mov)       
            StartCoroutine(Move(1f));
    }

    IEnumerator Move(float x)
    {
        mov = true;
        RandX = Random.Range(-1f, 1f);
        RandY = Random.Range(-1f, 1f);
       // Debug.Log("X" + RandX + " Y" + RandY);
        body.MovePosition(body.position + new Vector2(RandX, RandY).normalized * speed * Time.deltaTime);
      //  anim.SetFloat("x", RandX);
        yield return new WaitForSeconds(x);
        //Debug.Log("ACAbado");
        mov = false;
    }

}
