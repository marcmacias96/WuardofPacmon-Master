using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPersonajes : MonoBehaviour {
    string nombre;
    public Transform generador;
    public GameObject[] personajes;
    // Use this for initialization
    void Start () {
        nombre = EstadoJuego.estadoJuego.jugador;

        for (int i = 0; i < personajes.Length; i++)
        {

            if (nombre == personajes[i].name)
            {

                Instantiate(personajes[i], generador.position, generador.rotation);
            }
        }
        
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
