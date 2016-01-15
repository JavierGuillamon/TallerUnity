using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    private float CdInSeconds = 1f;
    private float timeStamp;
    public GameObject BalaGo;
    public Transform Spawn;
    private PlayerMovement pm;
    private Bala bala;
    private float Xaux, Yaux;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }
    void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            detectPosition(pm.getX(), pm.getY());
            if (timeStamp <= Time.time)
            {
                pm.ShieldOn(Xaux,Yaux);
               
                timeStamp = Time.time + CdInSeconds;
                StartCoroutine(Wait(.5f, 0.1f));
            }
            else
            {
                float left = timeStamp - Time.time;
                Debug.Log("NO entro " + left);
            }
        }
    }
    void detectPosition(float X, float Y)
    {
        bala = BalaGo.GetComponent<Bala>();
        if (Mathf.Abs(X) < Mathf.Abs(Y))
        {
            Xaux = 0;
            if (Y >= 0)
            {
                bala.setSpeed(new Vector2(0, 1));
                Yaux = 1;
            }
            else
            {
                bala.setSpeed(new Vector2(0, -1));
                Yaux = -1;
            }
        }
        else
        {
            Yaux = 0;
            if (X >= 0)
            {
                bala.setSpeed(new Vector2(1, 0));
                Xaux = 1;
            }
            else
            {
                bala.setSpeed(new Vector2(-1, 0));
                Xaux = -1;
            }
        }
    }
    IEnumerator Wait(float x,float y)
    {
        yield return new WaitForSeconds(x);
        GameObject bala = (GameObject)Instantiate(BalaGo, Spawn.position, Quaternion.identity);
        Transform child = bala.transform.Find("BalaSprite");
        anim = child.GetComponent<Animator>();
        anim.SetFloat("x", Xaux);
        anim.SetFloat("y", Yaux);
        yield return new WaitForSeconds(y);
        pm.ShieldOff();
    }
}
