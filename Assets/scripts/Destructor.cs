using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {
    private string nombre;
    private GameObject personaje;
    // Use this for initialization
    void Start () {
        nombre = camaraSeg.nombre;
	}
	
    // Update is called once per frame
    void Update () {
        
    }

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
            ActivarColores.nomorir = false;
            NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
            NotificationCenter.DefaultCenter().PostNotification(this, "Desactivar2");
           
            other.gameObject.SetActive(false);


        }
        else{
			Destroy(other.gameObject);
		}
	}
}
