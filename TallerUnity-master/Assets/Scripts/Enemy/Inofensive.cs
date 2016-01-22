using UnityEngine;
using System.Collections;

public class Inofensive : MonoBehaviour {

    public int Lives;
    public GameObject go;
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Lives != 1)
            Lives--;
        else
            Destroy(go);
        
    }
}
