using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {
    public PlayerControl pm;

    public void resume () {
        pm.PauseMenuOFF();
	}
	
}
