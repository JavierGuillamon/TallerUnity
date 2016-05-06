using UnityEngine;
using System.Collections;

public class DoorDetect : MonoBehaviour {
    public CargarEscena ce;
    public int NumeroEscena;
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            ce.LoadScene(NumeroEscena);
        }
    }
}
