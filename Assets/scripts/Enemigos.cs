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
    public int puntosGanados = 3;
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
        if(nomorir)
        {
            GetComponent<Animator>().SetBool("pumped", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("pumped", false);
        }
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad, GetComponent<Rigidbody2D>().velocity.y);
    }
    void Desactivar2()
    {
        
        nomorir = ActivarColores.nomorir;
        GetComponent<Animator>().SetBool("pumped", true);

    }
   void  OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            if(nomorir)
            {
                Destroy(obj);
                NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados);
                
            }
            else
            {
               
                other.gameObject.GetComponent<Animator>().SetBool("muerto",true);
                Invoke("Muerto", 1);
                NotificationCenter.DefaultCenter().PostNotification(this, "Quieto");

            }
            
        }

    }
    
   void Muerto()
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
    }
   
}
