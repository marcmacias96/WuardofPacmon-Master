using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonPause : MonoBehaviour {
    private bool muerto=false;
	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
    }
    void PersonajeHaMuerto()
    {
        muerto = true;
    }
    void OnMouseDown()
    { 
        if(!muerto)
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "ActivarPause");
            Time.timeScale = 0;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
