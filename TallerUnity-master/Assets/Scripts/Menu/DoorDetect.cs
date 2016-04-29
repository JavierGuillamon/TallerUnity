using UnityEngine;
using System.Collections;

public class DoorDetect : MonoBehaviour {
    public CargarEscena ce;
    public int NumeroEscena;
	void OnTriggerEnter2D(Collider2D other)
    {
        ce.LoadScene(NumeroEscena);
    }
}
