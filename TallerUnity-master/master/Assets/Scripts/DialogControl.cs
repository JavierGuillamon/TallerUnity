using UnityEngine;
using System.Collections;

public class DialogControl : MonoBehaviour
{
    public GameObject dialog;
    private SpriteRenderer rend;
    // Use this for initialization
    void Start()
    {
        rend = dialog.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        Debug.Log(otro.tag +"enter");
        if(otro.tag == "Player")
            rend.enabled = true;
    }

    void OnTriggerExit2D(Collider2D otro)
    {
        Debug.Log(otro.tag + "EXIT");
        if (otro.tag == "Player")
            rend.enabled = false;
    }
}