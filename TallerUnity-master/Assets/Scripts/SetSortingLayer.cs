using UnityEngine;
using System.Collections;

public class SetSortingLayer : MonoBehaviour {
    public Transform Target;
    public Transform Reference;
    public SpriteRenderer rend;
	// Update is called once per frame
	void Update () {
	    if(Target.position.y> Reference.position.y)
        {
            rend.sortingLayerName = "Overlay";
        }
        else
        {
            rend.sortingLayerName = "Suelo";
        }
            
	}
}
