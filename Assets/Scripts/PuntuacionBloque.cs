using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacionBloque : MonoBehaviour
{

    private bool colisionJugador = false;
    public int puntuacionIncrementar = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!colisionJugador && collision.contacts[0].collider.gameObject.name == "Pies")
        {
            colisionJugador = true;
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntuacion", puntuacionIncrementar);

        }
    }


}
