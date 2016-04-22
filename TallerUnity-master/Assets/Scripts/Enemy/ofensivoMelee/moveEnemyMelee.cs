using UnityEngine;
using System.Collections;

public class moveEnemyMelee : MonoBehaviour {
    public Transform target;
    public Transform tr;
    public Animator anim;
    public Rigidbody2D body;
    public float speed = 1;
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
    void Update()
    {
        if (!mov)
            StartCoroutine(Move(1f));

    }
    IEnumerator Move(float x)
    {
        mov = true;
        // Debug.Log("X" + RandX + " Y" + RandY);
        //body.MovePosition(body.position + new Vector2(RandX, RandY).normalized * speed * Time.deltaTime);
        //  anim.SetFloat("x", RandX);
        tr.position = Vector2.MoveTowards(tr.position,target.position,speed*Time.deltaTime);
        yield return new WaitForSeconds(x);
        //Debug.Log("ACAbado");
        mov = false;
    }

}
