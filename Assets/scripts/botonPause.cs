using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonPause : MonoBehaviour {
    private bool muerto=false;
    public GameObject camara;
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
            Time.timeScale = 0;
            NotificationCenter.DefaultCenter().PostNotification(this, "ActivarPause");
            camara.SetActive(true);
            
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
