using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour {

    public Animator anim;
    public PlayerMovement player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerMovement>();

    }
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            StartCoroutine(Wait(1));
        }
    }
    IEnumerator Wait(int x)
    {
        player.recibirDaño();
        yield return new WaitForSeconds(x);
        player.recibirDañoOff();
    }
}
