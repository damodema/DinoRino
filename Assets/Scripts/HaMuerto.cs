using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaMuerto : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Muerte personaje.
            NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");

            GameObject personaje = GameObject.Find("DinoRino");
            personaje.SetActive(false);
        }
    }
}
