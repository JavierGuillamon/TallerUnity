using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Animator anim;
    public Rigidbody2D body;
    public float speed = 1;
    float input_X, input_Y;
    float mouse_X, mouse_Y, player_X, player_Y;

    void FixedUpdate () {

        if (body == null)
            body = GetComponent<Rigidbody2D>();
     
        input_X = Input.GetAxisRaw("Horizontal");
        input_Y = Input.GetAxisRaw("Vertical");

        mouse_X = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;//coordenada del raton respecto a la camara principal
        mouse_Y = Camera.main.ScreenToWorldPoint( Input.mousePosition).y;

        player_X = transform.position.x;
        player_Y = transform.position.y;

        body.MovePosition(body.position + new Vector2(input_X, input_Y).normalized * speed * Time.deltaTime);

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
    public float getX()
    {
        return mouse_X-player_X;
    }
    public float getY()
    {
        return mouse_Y - player_Y;
    }
    public void ShieldOn(float x, float y)
    {
        anim.SetFloat("x", x);
        anim.SetFloat("y", y);
        anim.SetBool("Shield", true);
    }
    public void ShieldOff()
    {
        anim.SetBool("Shield", false);
    }
}
