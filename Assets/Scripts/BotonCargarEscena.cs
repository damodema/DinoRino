using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonCargarEscena : MonoBehaviour {

    public string nombreEscenaParaCargar = "GameScene";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Invoke("cargarNuevoNivel", GetComponent<AudioSource>().clip.length);
    }

    void cargarNuevoNivel()
    {
        SceneManager.LoadScene(nombreEscenaParaCargar);
    }
}
