using UnityEngine;
using System.Collections;

public class CargarEscena : MonoBehaviour
{
    public PlayerControl pm;
    public GameObject LoadImage;
    public bool cerrar;
    public bool reactivarTiempo;
    public Canvas can;
    public void LoadScene(int scene)
    {
        if (scene == -1) Application.Quit();   
        else
        {           
            LoadImage.SetActive(true);
            if (cerrar) can.enabled=false;
            Application.LoadLevel(scene);
        }
        if(reactivarTiempo) pm.PauseMenuOFF(); ;
    }
}
