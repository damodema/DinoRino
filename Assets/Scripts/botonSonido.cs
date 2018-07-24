using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonSonido : MonoBehaviour {
    

    private bool suena = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void sonido()
    {
        if (suena)
        {
            Camera.main.GetComponent<AudioSource>().Stop();
            suena = false;
        }
        else
        {
            Camera.main.GetComponent<AudioSource>().Play();
            suena = true;
        }
            
    }
}
