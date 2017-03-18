using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJuagar : MonoBehaviour {
    public GameObject PantallaSeleccionPersonaje;
   
	
	public GameObject titutloJugar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
       
        PantallaSeleccionPersonaje.SetActive(true);
		titutloJugar.SetActive (false);
    }

   
}
