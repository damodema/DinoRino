using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    public float velocidad = 0f;
    Material _Material;
    private bool enMovimiento = false;
    private float tiempoInicio = 0f;
	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "ComienzaACorrer");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        _Material = GetComponent<Renderer>().material;
    }


    void PersonajeHaMuerto()
    {
        enMovimiento = false;
    }
    void ComienzaACorrer()
    {
        enMovimiento = true;
        tiempoInicio = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if(enMovimiento)
            _Material.SetTextureOffset("_MainTex", new Vector2((Time.time - tiempoInicio) * velocidad % 1, 0));
    }
}
