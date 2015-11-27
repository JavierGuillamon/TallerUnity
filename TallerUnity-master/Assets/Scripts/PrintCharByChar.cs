using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrintCharByChar : MonoBehaviour {
    public string Text;
    private int position;
    private float delay = 0.1f;
    public Text tDialogue;
    //string[] addLines;
	// Use this for initialization
	void Start () {
       // tDialogue = getComponent<Text>();

      /*  for (int i = 0; i<=addLines.Length; i++) {
            Text +="\n"+addLines[i];
        }*/
        print();
	}
    IEnumerator print()
    {
        Debug.Log("ENTRO");
        while (true) { 
            if (position < Text.Length)
            {
                tDialogue.text += Text[position];
                Debug.Log("letra: " + Text[position]);
            }
            yield return new WaitForSeconds(delay);
        }
    }

	public void write(string aux)
    {
        tDialogue.text = "";
        position = 0;
        Text = aux;
    }
}
