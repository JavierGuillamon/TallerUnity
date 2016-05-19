using UnityEngine;
using System.Collections;

public class moveEnemyMelee : MonoBehaviour {
    public Transform target;
    public Transform tr;
    public Animator anim;
    public Rigidbody2D body;
    public float speed = 1;
    bool mov = false;
    public float scaleRangeMin = 0.8f;
    public float scaleRangeMax = 1.2f;
    float scale;
    void Start()
    {
        tr = GetComponent<Transform>();
        scale = Random.Range(scaleRangeMin, scaleRangeMax);
        tr.localScale *= scale;
        speed *= scale;
       // anim.speed *= scale;
        StartCoroutine(esperar());
    }

    // Update is called once per frame
    void Update()
    {
        if (!mov)
        {
            StartCoroutine(Move(scale));
        }
    }
    IEnumerator Move(float x)
    {
        mov = true;
        Vector2 direction= target.position-tr.position;
        direction.Normalize();
        body.MovePosition(body.position+ direction*speed * Time.deltaTime);
        yield return new WaitForSeconds(x);
        body.velocity = Vector2.zero;
        yield return new WaitForSeconds(x);
        mov = false;
    }
    IEnumerator esperar()
    {
        mov = true;
        yield return new WaitForSeconds(1f);
        mov = false;
    }

}
