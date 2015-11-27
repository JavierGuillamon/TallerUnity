using UnityEngine;
using System.Collections;

public class OsoMov : MonoBehaviour
{

    public Transform Target;
    public float m_speed;

    void Start() { }

    void Update()
    {
        //transform.LookAt(Target);//apunta al objetivo
        Vector3 moveVect = (Target.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, Target.position) > 0.8f)
        {
            //se mueve si la distancia entre el objetivo y este es mayor que 0.8
            transform.Translate(moveVect * m_speed * Time.deltaTime);
        }
    }
}