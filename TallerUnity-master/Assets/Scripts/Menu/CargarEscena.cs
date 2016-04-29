using UnityEngine;
using System.Collections;

public class CargarEscena : MonoBehaviour {
    public GameObject LoadImage;
	public void LoadScene(int scene)
    {
        LoadImage.SetActive(true);
        Application.LoadLevel(scene);
    }
}
