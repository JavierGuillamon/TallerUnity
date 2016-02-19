using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
    public int Lives;
    public Animator anim;
    public GameObject go;
    public float tiempoAnimDaño;
    public float tiempoAnimMorir;
    public ShootControl shootControl;
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bala")
        {
            StartCoroutine(recibirDaño(tiempoAnimDaño));
            if (Lives != 1)
                Lives--;
            else
                StartCoroutine(morir(tiempoAnimDaño));

        }
    }
    IEnumerator recibirDaño(float x)
    {
        anim.SetBool("damage", true);
        yield return new WaitForSeconds(x);
        anim.SetBool("damage", false);
    }
    IEnumerator morir(float x)
    {
        anim.SetBool("damage", true);
        yield return new WaitForSeconds(x);
        Destroy(go);
    }

    void atacar()
    {
        shootControl.Shoot();
    }
}
