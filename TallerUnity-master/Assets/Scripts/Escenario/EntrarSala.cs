using UnityEngine;
using System.Collections;

public class EntrarSala : MonoBehaviour {
    public SpriteRenderer[] spritesRenders;
    public Sprite[] sprites;


    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i< spritesRenders.Length; i++){
            Debug.Log("ANSADA" + i);
            spritesRenders[i].sprite = sprites[i];
        }

    }
}
