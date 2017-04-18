using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionPerso : MonoBehaviour {
    private string nombre;
    private void Start()
    {
        /*if(tag!="ECUATORIANO")
        {
            GetComponent<Animator>().SetBool("Disabled", true);
            GetComponent<Button>().interactable = false;
        }*/
        
    }
    public void Nombre()
    {
        nombre = tag;
        EstadoJuego.estadoJuego.jugador = nombre;
        Debug.Log(nombre);
    }
    
    
}
