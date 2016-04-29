using UnityEngine;
using System.Collections;

public class EntrarSala : MonoBehaviour {
    public SpriteRenderer[] spritesRenders;
    public Sprite[] sprites;
    int cont = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (cont == 0)
        {
            cont = 1;
            for (int i = 0; i < spritesRenders.Length; i++)
            {
                spritesRenders[i].sprite = sprites[i];
            }
        }
    }
}
