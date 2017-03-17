using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class JugadorSelec : MonoBehaviour {
    public  string nombre;
    public GameObject Ecuatoriano;
    public GameObject Peruano ;
    public static JugadorSelec transJugador;
    public Transform seleccionado;
    public bool entro = false;
    public static GameObject personaje;
    // Use this for initialization
    void Start () {
        nombre = EstadoJuego.estadoJuego.jugador;
        
        
    }
	
	// Update is called once per frame
	void Update () {
      
       /* if (nombre == "Ecuatoriano")
        {
            Peruano.SetActive(false);
            entro = true;

        }
        else
        {
            if (nombre == "Peruano")
            {
               Ecuatoriano.SetActive(false);

                entro = true;
            }
        }*/
    }
}
