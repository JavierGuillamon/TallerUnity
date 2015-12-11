using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    private float CdInSeconds = 1f;
    private float timeStamp;
    public GameObject Bala;
    public Transform Spawn;

    private float X, Y;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if(timeStamp<= Time.time)
            {
               // X = PlayerMovement.X;

                //Debug.Log("Entro "+X);
                Instantiate(Bala, Spawn.position, Quaternion.identity);

                timeStamp = Time.time + CdInSeconds;
            }
            else
            {
                float left = timeStamp - Time.time;
                Debug.Log("NO entro "+left);
            }
        }


        /*
            X Y
        dch 1 0
        izq -1 0
        up  0 1
        dn  0 -1
        */
    }
}
