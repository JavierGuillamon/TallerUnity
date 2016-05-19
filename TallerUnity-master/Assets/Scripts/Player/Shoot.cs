using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    private float timeStamp;
    public GameObject BalaGo;
    public GameObject FuerzaGo;
    public Transform Spawn;
    private PlayerControl pm;
    private Bala bala;
    private float Xaux, Yaux;
    private Animator anim;
    public float CdInSeconds = 1f;
    public float velocidadBala;
    public AudioSource audioAtck1;
    public AudioSource audioAtck2;
    // Use this for initialization
    void Start()
    {
        pm = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }
    void fire()
    {
        if (pm.canMove)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                detectPosition(pm.getX(), pm.getY(), BalaGo);
                if (timeStamp <= Time.time)
                {
                    pm.ShieldOn(Xaux, Yaux);
                    timeStamp = Time.time + CdInSeconds;
                    StartCoroutine(WaitShoot1(.5f, 0.1f));
                }
                else
                {
                    float left = timeStamp - Time.time;
                }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                detectPosition(pm.getX(), pm.getY(), FuerzaGo);
                if (timeStamp <= Time.time)
                {
                    pm.ShieldOn(Xaux, Yaux);
                    timeStamp = Time.time + CdInSeconds;
                    StartCoroutine(WaitShoot2(.5f, 0.1f));
                }
            }
            if (Input.GetButtonDown("Pause"))
            {
                pm.PauseMenuOn();
            }
        }
    }
    void detectPosition(float X, float Y, GameObject go)
    {
        bala = go.GetComponent<Bala>();
        if (Mathf.Abs(X) < Mathf.Abs(Y))
        {
            Xaux = 0;
            if (Y >= 0)
            {
                bala.setSpeed(new Vector2(0, velocidadBala));
                Yaux = velocidadBala;
            }
            else
            {
                bala.setSpeed(new Vector2(0, -velocidadBala));
                Yaux = -velocidadBala;
            }
        }
        else
        {
            Yaux = 0;
            if (X >= 0)
            {
                bala.setSpeed(new Vector2(velocidadBala, 0));
                Xaux = velocidadBala;
            }
            else
            {
                bala.setSpeed(new Vector2(-velocidadBala, 0));
                Xaux = -velocidadBala;
            }
        }
    }
    IEnumerator WaitShoot1(float x,float y)
    {
        yield return new WaitForSeconds(x);
        GameObject bala = (GameObject)Instantiate(BalaGo, Spawn.position, Quaternion.identity);
        Transform child = bala.transform.Find("BalaSprite");
        audioAtck1.Play();

        yield return new WaitForSeconds(y);
        pm.ShieldOff();
    }
    IEnumerator WaitShoot2(float x, float y)
    {
        yield return new WaitForSeconds(x);
        GameObject fuerza = (GameObject)Instantiate(FuerzaGo, Spawn.position, Quaternion.identity);
        Transform child = fuerza.transform.Find("FuerzaSprite");
        audioAtck2.Play();

        anim = child.GetComponent<Animator>();
        anim.SetFloat("x", Xaux);
        anim.SetFloat("y", Yaux);

        yield return new WaitForSeconds(y);
        pm.ShieldOff();
    }
}
