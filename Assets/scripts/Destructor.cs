using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {
    private string nombre;
    private GameObject personaje;
    // Use this for initialization
    void Start () {
	
	}
	
    // Update is called once per frame
    void Update () {
        nombre = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>().jugador;
    }

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
            ActivarColores.nomorir = false;
            NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
            NotificationCenter.DefaultCenter().PostNotification(this, "Desactivar2");
            if (nombre == "Ecuatoriano")
            {
                personaje = GameObject.Find("ECUATORIANO");
                personaje.SetActive(false);
            }
            else
            {
                if (nombre =="Peruano")
                {
                    personaje = GameObject.Find("PERUANO");
                    personaje.SetActive(false);
                }
            }
           
           
            
        }
        else{
			Destroy(other.gameObject);
		}
	}
}
