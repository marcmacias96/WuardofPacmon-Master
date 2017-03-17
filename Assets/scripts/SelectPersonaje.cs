using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SelectPersonaje : MonoBehaviour {
    public TextMesh nombrePerso;
    private string nombre;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
   
    void OnMouseDown()
    {
       
        GetComponent<AudioSource>().Play();
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 20);
        nombre = GetComponent<Collider2D>().tag;
        nombrePerso.text = nombre;
        EstadoJuego.estadoJuego.jugador = nombre;
      
        
    }
   
}
