using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public int puntuacionIncrementar = 5;
    public AudioClip cogerItemClip;
    public float volumen = 0.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(this.gameObject.tag == "Item" || this.gameObject.tag == "Astronauta")
            {
                AudioSource.PlayClipAtPoint(cogerItemClip, Camera.main.transform.position, volumen);
                NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntuacion", puntuacionIncrementar);
            }
            else if(this.gameObject.tag == "Cometa")
            {
                NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
                GameObject personaje = GameObject.Find("DinoRino");
                personaje.SetActive(false);
            }
            
        }

        Destroy(this.gameObject);
    }
}
