using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzaSalto = 5f;
	private bool enSuelo = true;
	public Transform comprobadorSuelo;
    public Transform comprobadorSuelo2;
    private float comprobadorRadio = 0.07f;
	public LayerMask mascaraSuelo;
	private bool dobleSalto = false;
	private Animator animator;
    private float velextra = 0.01f;

    //correr
    public bool corriendo = false;
	public float velocidad = 7f;

	void Awake(){
		animator = GetComponent<Animator> ();
	}

    void Start()
    {
    }
    //Para tratar cosas con fisica, esta función se llamará cada cierto 
    //tiempo constante no cada fotograma
    void FixedUpdate(){

		if (corriendo) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocidad, GetComponent<Rigidbody2D> ().velocity.y);
		}

		animator.SetFloat ("VelX",GetComponent<Rigidbody2D> ().velocity.x);
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo) || Physics2D.OverlapCircle(comprobadorSuelo2.position, comprobadorRadio, mascaraSuelo) ;
        animator.SetBool ("isGrounded",enSuelo);

		if(enSuelo){
			dobleSalto = false;
		}
	}

	// Update is called once per frame
	//Funcion que se ejecuta en todos los fotogramas del juego 
	void Update () {

        velextra = (Time.time % 5f);

        if (Input.GetMouseButtonDown(0)) {
			if (corriendo) {
				//Queremos que salte
				if(enSuelo || !dobleSalto){
                    GetComponent<AudioSource>().Play();
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + velextra,fuerzaSalto);
					
					if (!dobleSalto && !enSuelo) {
						dobleSalto = true;
					}
				}
			} else {
				corriendo = true;
                velextra = 0.01f;
                NotificationCenter.DefaultCenter().PostNotification(this, "ComienzaACorrer");
            }
		}
    }
}
