using UnityEngine;
using System.Collections;

public class Inofensive : MonoBehaviour {

    public int Lives;
    public Animator anim;
    public GameObject go;
    public float tiempoAnimDaño;
    public float tiempoAnimMorir;

    public GameObject sensorEntrada;

    public int inofensive;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bala")
        {
            if (inofensive == 1)  StartCoroutine(recibirDaño(tiempoAnimDaño));
            audioSource.Play();

            if (Lives != 1)
            {
                Lives--;
            }
            else
            {
                Debug.Log("MUERO");
                StartCoroutine(morir(tiempoAnimDaño));
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Bala")
        {
            audioSource.Play();
            if (inofensive == 1) StartCoroutine(recibirDaño(tiempoAnimDaño));
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
        Debug.Log("1");
        sensorEntrada.GetComponent<Spawn>().deadCount++;
        Debug.Log("2");
        if (inofensive == 1) anim.SetBool("dead", true);
        Debug.Log("3");
        yield return new WaitForSeconds(x);
        Debug.Log("4");
        Destroy(go);
        Debug.Log("5");
    }
}
