using UnityEngine;
using System.Collections;

public class EntrarSala : MonoBehaviour {
    public GameObject[] puertas;
    public SpriteRenderer[] spritesRendersCaras;
    public SpriteRenderer[] spritesRendersEsquinas;
    public Sprite spriteEncendidoCara;
    public Sprite spriteApagadoCara;
    public Sprite spriteEncendidoEsquina;
    public Sprite spriteApagadoEsquina;
    public Spawn spawn;
    int cont = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            EncenderSala();
        }
    }
    public void EncenderSala()
    {
        if (cont == 0)
        {
            spawn.wave = 0;
            cont = 1;
            for (int i = 0; i < spritesRendersCaras.Length; i++)
            {
                spritesRendersCaras[i].sprite = spriteEncendidoCara;
            }
            for(int i = 0; i < spritesRendersEsquinas.Length; i++)
            {
                spritesRendersEsquinas[i].sprite = spriteEncendidoEsquina;
            }
            for(int i=0; i < puertas.Length; i++)
            {
                puertas[i].SetActive(true);
            }
        }
    }
    public void ApagarSala()
    {
        for (int i = 0; i < spritesRendersCaras.Length; i++)
        {
            spritesRendersCaras[i].sprite = spriteApagadoCara;
        }
        for (int i = 0; i < spritesRendersEsquinas.Length; i++)
        {
            spritesRendersEsquinas[i].sprite = spriteApagadoEsquina;
        }
        for (int i = 0; i < puertas.Length; i++)
        {
            puertas[i].SetActive(false);
        }
    }
}
