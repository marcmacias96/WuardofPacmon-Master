﻿using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {
    public Camera mainCamara;
    private string nombre;
    private GameObject personaje;
    public bool entra;
    // Use this for initialization
    void Start () {
        nombre = camaraSeg.nombre;
	}
	
    // Update is called once per frame
    void Update () {
        
    }

	void OnTriggerEnter2D(Collider2D other){
        entra = true;
		if(other.tag == "Player"){
            mainCamara.GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
            ActivarColores.nomorir = false;
            NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
            NotificationCenter.DefaultCenter().PostNotification(this, "Desactivar2");
           
            other.gameObject.SetActive(false);


        }
        else{
			Destroy(other.gameObject);
		}
	}
}
