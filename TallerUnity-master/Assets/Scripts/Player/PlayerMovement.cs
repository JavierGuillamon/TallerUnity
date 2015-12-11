using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Animator anim;

    public Rigidbody2D body;
	
	void FixedUpdate () {

        if (body == null)
            body = GetComponent<Rigidbody2D>();

        int input_X = 0;
        int input_Y = 0;

        if (Input.GetButton("Left"))
        {
            input_X = -1;
        }
        if (Input.GetButton("Right"))
        {
            input_X = 1;
        }
        if (Input.GetButton("Down"))
        {
            input_Y = -1;
        }
        if (Input.GetButton("Up"))
        {
            input_Y = 1;
        }

        float mouse_X = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;//coordenada del racton respecto a la camara principal
        float mouse_Y = Camera.main.ScreenToWorldPoint( Input.mousePosition).y;

        float player_X = transform.position.x;
        float player_Y = transform.position.y;

        body.MovePosition(body.position + new Vector2(input_X, input_Y) * Time.deltaTime*0.5f);

        bool isWalking = (Mathf.Abs (input_X) + Mathf.Abs (input_Y)) > 0; 
		anim.SetBool ("isWalking", isWalking);
		if (isWalking) {
			anim.SetFloat("x",mouse_X-player_X);
			anim.SetFloat("y",mouse_Y-player_Y);
		}
        else
        {
            anim.SetFloat("x", mouse_X - player_X);
            anim.SetFloat("y", mouse_Y - player_Y);
        }

	}
}
