using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovIzq : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            MovPakVsBos.dere = false;
            MovPakVsBos.izq = true;
        }
    }
}
