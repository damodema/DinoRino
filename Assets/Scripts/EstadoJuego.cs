using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class EstadoJuego : MonoBehaviour
{

    public static EstadoJuego estadoJuego;
    public int puntuacionMaxima = 0;
    public string rutaArchivo;


    private void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/datos.dat";

        if (estadoJuego == null)
        {
            estadoJuego = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (estadoJuego != this)
        {
            Destroy(this.gameObject);
        }


    }

    // Use this for initialization
    void Start()
    {
        cargar();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(rutaArchivo, FileMode.Create);

        DatosGuardar datos = new DatosGuardar(puntuacionMaxima);

        bf.Serialize(fs, datos);

        fs.Close();
    }


    public void cargar()
    {
        if (File.Exists(rutaArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(rutaArchivo, FileMode.Open);

            DatosGuardar datos = (DatosGuardar)bf.Deserialize(fs);

            puntuacionMaxima = datos.puntuacion;
            fs.Close();
        }
        else
        {
            puntuacionMaxima = 0;
        }

    }

    [Serializable]
    class DatosGuardar
    {
        public int puntuacion;

        public DatosGuardar(int _puntuacion)
        {
            this.puntuacion = _puntuacion;
        }

    }

}
