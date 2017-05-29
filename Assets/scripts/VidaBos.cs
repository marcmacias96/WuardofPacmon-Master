﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBos : MonoBehaviour {
    public float Vida = 10;
    string text;
    public int golpe;
    public GameObject BarraVida;
    public GameObject camaraFinNivel;
	// Use this for initialization
	void Start () {
       
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
    }
	
	// Update is called once per frame
	void Update () {
		if(Vida<0)
        {
            Destroy(gameObject);
            camaraFinNivel.SetActive(true);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "meemperra")
        {
            Destroy(collision.gameObject);
            Vida -= golpe;
            NotificationCenter.DefaultCenter().PostNotification(this, "VidaBoss", golpe);
        }
    }
    void PersonajeHaMuerto()
    {

        BarraVida.SetActive(false);
    }


}
