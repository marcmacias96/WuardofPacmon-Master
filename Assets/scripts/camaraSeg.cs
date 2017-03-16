using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class camaraSeg : MonoBehaviour {
    public Transform personaje;
    public string nombre;
    public JugadorSelec jugadorselec;
    // Use this for initialization
    void Start () {
        nombre = EstadoJuego.estadoJuego.jugador;
        jugadorselec = GameObject.Find("Main Camera").GetComponent<JugadorSelec>();
        if (nombre == "Ecuatoriano")
        {
            personaje = jugadorselec.Ecuatoriano.GetComponent<Transform>();
        }
        if (nombre == "Peruano")
        {
            personaje = jugadorselec.Peruano.GetComponent<Transform>();
        }
    }

    public float separacion = 6f;

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(personaje.position.x + separacion, transform.position.y, transform.position.z);
    }

}
