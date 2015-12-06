using UnityEngine;
using System.Collections;

public class MovBox : MonoBehaviour {
    public Transform Box;
    public enum direcciónMovimiento {IZQUIERDA,DERECHA,ARRIBA,ABAJO}
    public direcciónMovimiento direccion;
    public float mov;
    private float X, Y;

    void OnTriggerEnter2D(Collider2D otro)
    {
        switch (direccion)
        {
            case direcciónMovimiento.ABAJO:
                {                    
                    Debug.Log("ABAJO"+Box.position+" "+mov);
                    Box.Translate(new Vector3(0, mov,0));
                    //Box.position = new Vector3(0, 3, 0).normalized * Time.deltaTime;
                    Debug.Log("ABAJO2" + Box.position + " " + mov);
                    break;
                }
            case direcciónMovimiento.ARRIBA:
                { 
                    Debug.Log("ARRIBA");
                    Box.position += new Vector3(0, -mov, 0).normalized * Time.deltaTime;
                    break;
                }
            case direcciónMovimiento.IZQUIERDA:
                {
                    Debug.Log("IZQUIERDA");
                    Box.position += new Vector3(mov, 0, 0).normalized * Time.deltaTime;
                    break;
                }
            case direcciónMovimiento.DERECHA:
                {
                    Debug.Log("DERECHA");
                    Box.position += new Vector3(-mov, 0, 0).normalized * Time.deltaTime;
                    break;
                }
                
        }
    }
}
