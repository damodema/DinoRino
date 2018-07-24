using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{

    public GameObject[] obj;
    private bool generar = true;
    public float tiempoMin = 2.5f;
    public float tiempoMax = 5f;

    // Use this for initialization
    void Start()
    {

        NotificationCenter.DefaultCenter().AddObserver(this, "ComienzaACorrer");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
    }

    void PersonajeHaMuerto()
    {
        generar = false;
    }

    void ComienzaACorrer(Notification notification)
    {
        Generar();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void Generar()
    {
        if (generar)
        {

            Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);

            Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
        }

    }
}
