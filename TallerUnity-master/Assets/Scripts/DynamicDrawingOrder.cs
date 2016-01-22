using UnityEngine;
using System.Collections;

public class DynamicDrawingOrder : MonoBehaviour {

    public SpriteRenderer sprite;

    static float resolution = 1000;

    public int offset = 0;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        sprite.sortingOrder = (int)(-transform.position.y * resolution) + offset;
    }
}
