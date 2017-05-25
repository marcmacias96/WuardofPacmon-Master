using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBos : MonoBehaviour {
    [Header("Bombardeo")]
    public GameObject Bombas;
    public Transform disparador1;
    public Transform disparador2;
    public float fireRate;
    public float nexFire = 0;
    [Header("Movimiento")]
    public float velocidad2;
    public float rate;
    public static bool pantalla = false;
    public bool entra = false;
    public static bool Dere, dispara;
    private float nextChange;
    private string name;
    public  GameObject jugador;
    private Vector2 posJugador;
    
    // Use this for initialization
    void Start () {
        name = EstadoJuego.estadoJuego.jugador;
        name = name + ("(Clone)");
        Debug.Log(name);
        Invoke("Encontrar", 0.1f);
	}
 
    // Update is called once per frame
    void FixedUpdate () {
        entra = pantalla;
        if ( Time.time > nextChange)
        {
            posJugador = jugador.GetComponent<Rigidbody2D>().velocity;
            if(posJugador.x>0)
            {
                Dere = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad2, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if(posJugador.x!=0)
            {
                Dere = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad2, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            
            
            nextChange = Time.time + rate;
        }
        if( Time.time > nexFire)
        {
            if(Dere)
            {
                nexFire = Time.time + fireRate;
                Instantiate(Bombas, disparador2.position, disparador2.rotation);
            }
            else
            {
                nexFire = Time.time + fireRate;
                Instantiate(Bombas, disparador1.position, disparador1.rotation);
            }
            
            
        }
      

    }
    void Encontrar()
    {
        jugador = GameObject.Find(name);
    }
}
