using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour {

    public int puntuacion = 0;
    public TextMesh marcador;

	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this,"IncrementarPuntuacion");
        NotificationCenter.DefaultCenter().AddObserver(this,"PersonajeHaMuerto");

        ActualizarMarcador();
    }

    void PersonajeHaMuerto()
    {
        if (puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima)
        {
            EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
            EstadoJuego.estadoJuego.guardar();
        }
    }

    void IncrementarPuntuacion(Notification notificacion)
    {
        int puntosAIncrementar = (int)notificacion.data;

        puntuacion += puntosAIncrementar;

        ActualizarMarcador();

        Debug.Log("Incrementando: "+puntosAIncrementar+" Puntos totales: "+puntuacion);

    }
    void ActualizarMarcador()
    {
        marcador.text = puntuacion.ToString();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
