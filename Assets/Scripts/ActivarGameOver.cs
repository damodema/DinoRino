using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarGameOver : MonoBehaviour {


    public GameObject camaraGameOver;
    public AudioClip gameOverClip;

	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
    }

    void PersonajeHaMuerto(Notification notif)
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = gameOverClip;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();
        camaraGameOver.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}


}
