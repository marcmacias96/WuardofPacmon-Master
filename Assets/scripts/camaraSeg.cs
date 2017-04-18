using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class camaraSeg : MonoBehaviour {
    public static Transform personaje;
    public static string nombre;
    public Transform generador;
    public GameObject[] personajes;

    // Use this for initialization
    void Start () {
        nombre = EstadoJuego.estadoJuego.jugador;
       
        for (int i=0;i<personajes.Length;i++)
        {
            
            if (nombre==personajes[i].name)
            {
                
                Instantiate(personajes[i], generador.position, generador.rotation);
            }
        }

        nombre += "(Clone)";
        personaje = GameObject.Find(nombre).GetComponent<Transform>();
        Debug.Log(nombre);
       
    }

    public float separacion = 6f;

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(personaje.position.x + separacion, transform.position.y, transform.position.z);
    }

}
