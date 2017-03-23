using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pantalla : MonoBehaviour {
    public bool entra = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        entra = true;
        MovPakVsBos.pantalla = true;
        MovimientoBos.pantalla = true;
    }
}
