﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public int vidas;

    public GameObject[] vidasImg;

    public Animator anim;

    public Rigidbody2D body;

    public float speed = 1;

    float input_X, input_Y;
    float mouse_X, mouse_Y, player_X, player_Y;

    public bool canMove = true;

    public float tiempoAnimDaño=0.5f;

    public Canvas canvasMenu;

    public AudioSource audioWalk;
    public AudioSource audioDamage;

    public Image fadeImg;

    void Start()
    {
        canvasMenu.enabled = false;
    }
    void FixedUpdate () {
        if (canMove)
        {
            if (body == null)
                body = GetComponent<Rigidbody2D>();

            input_X = Input.GetAxisRaw("Horizontal");
            input_Y = Input.GetAxisRaw("Vertical");

            mouse_X = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;//coordenada del raton respecto a la camara principal
            mouse_Y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

            player_X = transform.position.x;
            player_Y = transform.position.y;
       

        bool isWalking = (Mathf.Abs(input_X) + Mathf.Abs(input_Y)) > 0;
        anim.SetBool("isWalking", isWalking);
        if (canMove)
        {
            if (isWalking)
            {
                if (audioWalk.isPlaying == false) { audioWalk.Play(); }
                anim.SetFloat("x", mouse_X - player_X);
                anim.SetFloat("y", mouse_Y - player_Y);
            }
            else
            {
                anim.SetFloat("x", mouse_X - player_X);
                anim.SetFloat("y", mouse_Y - player_Y);
            }
        }
        }
        else
        {
            input_X = 0;
            input_Y = 0;
            player_X = 0;
            player_Y = 0;
        }
        body.MovePosition(body.position + new Vector2(input_X, input_Y).normalized * speed * Time.deltaTime);
    }
    public float getX()
    {
        return mouse_X-player_X;
    }
    public float getY()
    {
        return mouse_Y - player_Y;
    }
    public void ShieldOn(float x, float y)
    {
        //canMove = false;
        anim.SetFloat("x", x);
        anim.SetFloat("y", y);
        anim.SetBool("Shield", true);
    }
    public void ShieldOff()
    {
       // canMove = true;
        anim.SetBool("Shield", false);
    }
    public void recibirDaño()
    {
        if(vidas!=0) audioDamage.Play();
        anim.SetBool("isWalking", false);
        anim.SetBool("damage", true);
        vidas -= 1;
        vidasImg[(vidas)].SetActive(false);
        if (vidas == 0)
        {
            anim.SetBool("dead", true);
            canMove = false;
            StartCoroutine(Fade());
        }
        StartCoroutine(Wait(tiempoAnimDaño));
    }
    public void recibirDañoOff()
    {
        anim.SetBool("damage", false);
    }
    IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(x);
        recibirDañoOff();
    }

    public void PauseMenuOn()
    {
        canvasMenu.enabled = true;
        Time.timeScale = 0;
    }
    public void PauseMenuOFF()
    {
        canvasMenu.enabled = false;
        Time.timeScale = 1;
    }
    IEnumerator Fade()
    {
        while (fadeImg.color.a < 1)
        {
            Color aux =fadeImg.color;
            aux.a = aux.a + 0.01f;
            fadeImg.color = aux;
            yield return new WaitForSeconds(0.01f);
        }
        Application.LoadLevel(0);
        
    }
}
