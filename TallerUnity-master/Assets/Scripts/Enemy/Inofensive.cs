using UnityEngine;
using System.Collections;

public class Inofensive : MonoBehaviour {

    public int Lives;
    public Animator anim;
    public GameObject go;
    public float tiempoAnimDaño;
    public float tiempoAnimMorir;

    public GameObject sensorEntrada;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bala")
        {
            audioSource.Play();
            StartCoroutine(recibirDaño(tiempoAnimDaño));
            if (Lives != 1)
                Lives--;
            else
                StartCoroutine(morir(tiempoAnimDaño));                
        }
    }
    void OnTriggerExit2D(Collider2D other)
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
        sensorEntrada.GetComponent<Spawn>().deadCount++;
        anim.SetBool("dead", true);
        yield return new WaitForSeconds(x);
        Destroy(go);
    }
}
