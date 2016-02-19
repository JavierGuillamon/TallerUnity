using UnityEngine;
using System.Collections;

public class MovBox : MonoBehaviour {
   
    public Rigidbody2D Box;
    public float movUnits;
    public float movTime;
    void OnTriggerEnter2D(Collider2D coll)
    {
        Vector2 a = coll.transform.position;
        Vector3 colPos = coll.GetComponent<Rigidbody2D>().transform.position;
        float X = colPos.x - Box.transform.position.x;
        float Y = colPos.y - Box.transform.position.y;     
        if (Mathf.Abs(X) < Mathf.Abs(Y))
        {     
            if (Y >= 0)
            {
                StartCoroutine(move(movTime, 0, -movUnits));
            }
            else
            {
                StartCoroutine(move(movTime, 0, movUnits));
            }
        }
        else
        {   
            if (X >= 0)
            {
                StartCoroutine(move(movTime, -movUnits,0));
            }
            else
            {
                StartCoroutine(move(movTime, movUnits, 0));
            }
        }
    }
    IEnumerator move(float time, float X, float Y)
    {
        Debug.Log("EMpIEZA");
        Box.MovePosition(Box.position + new Vector2(X, Y) * Time.deltaTime * 0.5f);
        yield return new WaitForSeconds(time);
        Box.MovePosition(Box.position);
        Debug.Log("ACABA");
    }
}
