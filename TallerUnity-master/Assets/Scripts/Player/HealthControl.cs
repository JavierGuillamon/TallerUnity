using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour {

  //  public Animator anim;
    public PlayerControl player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerControl>();

    }
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
       {

            player.recibirDaño();
            //StartCoroutine(Wait(0));
        }
    }
    /*IEnumerator Wait(float x)
    {
        Debug.Log("DAÑO1");
        player.recibirDaño();
        Debug.Log("DAÑO2");
        yield return new WaitForSeconds(x);
        Debug.Log("DAÑO3");
        player.recibirDañoOff();
        Debug.Log("DAÑO4");
    }*/
}
