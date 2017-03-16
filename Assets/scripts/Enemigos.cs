using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public float velocidad = 1;
    private string nombre;
    private GameObject personaje;
   
    public bool entro=false;
    public static  bool nomorir=false;
    public GameObject obj;
    // Use this for initialization
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "Desactivar2");
       
        nombre = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>().jugador;
    }
    
    // Update is called once per frame
    void Update()
    {
        nomorir = ActivarColores.nomorir;
        GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad, GetComponent<Rigidbody2D>().velocity.y);
    }
    void Desactivar2()
    {
        
        nomorir = ActivarColores.nomorir;
    }
   void  OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            if(nomorir)
            {
                Destroy(obj);
            }
            else
            {
                NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");

                if (nombre == "Ecuatoriano")
                {
                    personaje = GameObject.Find("ECUATORIANO");
                    personaje.SetActive(false);
                }
                else
                {
                    if (nombre == "Peruano")
                    {
                        personaje = GameObject.Find("PERUANO");
                        personaje.SetActive(false);
                    }
                }
            }
            
        }

    }
}
