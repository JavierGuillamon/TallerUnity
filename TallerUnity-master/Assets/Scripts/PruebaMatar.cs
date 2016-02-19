using UnityEngine;
using System.Collections;

public class PruebaMatar : MonoBehaviour
{
    public Animator anim;
    void OnTriggerEnter2D(Collider2D coll)
    {
        anim.SetBool("dead", true);
    }
}
