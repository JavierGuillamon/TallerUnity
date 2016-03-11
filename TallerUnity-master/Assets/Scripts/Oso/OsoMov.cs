using UnityEngine;
using System.Collections;

public class OsoMov : MonoBehaviour
{
    public Animator anim;
    public Transform Target;
    public float m_speed;
    public float distanceToTarget;
    private bool isWalking;
    private float x,y;
    void Start() { }

    void Update()
    {
        //transform.LookAt(Target);//apunta al objetivo
        Vector3 moveVect = (Target.position - transform.position).normalized;
       
        x = Target.position.x - transform.position.x;
        y = Target.position.y - transform.position.y;
       
        anim.SetFloat("x", x);
        anim.SetFloat("y", y);
        if (Vector3.Distance(transform.position, Target.position) > distanceToTarget)
        {
            anim.SetBool("isWalking", true);
            transform.Translate(moveVect * m_speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}