using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPersonaje : MonoBehaviour {

	//Tendrán la posición rotación.
	public Transform DinoRino;
	public float separacion = 3.5f;
    public float separacionExtra = 0.1f;
    public bool comienza = false;

    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "ComienzaACorrer");
    }

    void ComienzaACorrer()
    {
        comienza = true;
        separacionExtra = 0.1f;
    }

    // Update is called once per frame
    void Update () {

        if(comienza){ 
		    transform.position = new Vector3 (transform.position.x + separacion + separacionExtra, transform.position.y,transform.position.z);

            separacionExtra = (Time.time % 10f) /1000;
        }
    }
}
