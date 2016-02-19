using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    [Multiline]
    public string Texto;
    public float seconds;
    public Canvas can;
    public Text TextDialog;

    public AudioClip clip;
    private AudioSource audio;
   void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        StopAllCoroutines();
        StartCoroutine(CharByChar());
        can.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D otro)
    {
        TextDialog.text = "";
        can.gameObject.SetActive(false);
    }
    
    IEnumerator CharByChar()
    {
        TextDialog.text = "";
        for (int i = 0; i < Texto.Length; i++)
        {
            TextDialog.text += Texto[i];
            //audio.PlayOneShot(clip, seconds);
            yield return new WaitForSeconds(seconds);
        }
    }
}