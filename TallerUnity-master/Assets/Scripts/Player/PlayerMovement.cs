using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		float input_X = Input.GetAxisRaw ("Horizontal");//este movimiento va a set muy seco, si quieres que sea mas fluido quita Raw
		float input_Y = Input.GetAxisRaw ("Vertical");//lo mismo

        float mouse_X = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;//coordenada del racton respecto a la camara principal
        float mouse_Y = Camera.main.ScreenToWorldPoint( Input.mousePosition).y;

        float player_X = transform.position.x;
        float player_Y = transform.position.y;
        /*
        restar coordenada mouse_x a coordenada del personaje, apartir de ahi scar la x y la y para ejecutar la animacion
        */

        Debug.Log(mouse_X + " " + mouse_Y);


		//sumar los valores absolutos de x e y, si el valor es 0 no se mueve, si es diferente se mueve
		bool isWalking = (Mathf.Abs (input_X) + Mathf.Abs (input_Y)) > 0; 
		anim.SetBool ("isWalking", isWalking);
		if (isWalking) {
			anim.SetFloat("x",mouse_X-player_X);
			anim.SetFloat("y",mouse_Y-player_Y);

			//normalizaed hace que se puedan pulsar dos teclas a la vez y mantener el mismo tiempo de ejecucion
			transform.position += new Vector3(input_X,input_Y,0).normalized*Time.deltaTime;
		}

	}
}
