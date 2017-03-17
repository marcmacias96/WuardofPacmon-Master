using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarColores : MonoBehaviour {
    public TextMesh puntuacion;
    public GameObject camara;
    public static bool nomorir = false;
   
    // Use this for initialization
    void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "DesactivarActivarColores");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
       
    }
	
	// Update is called once per frame
	void Update () {
		
        if(puntuacion.text.ToString().Equals("3"))
        {
            nomorir = true;
            camara.SetActive(true);
            NotificationCenter.DefaultCenter().PostNotification(this, "SystemPaticule",true);
        }

    }
    public bool des = false;
    void PersonajeHaMuerto()
    {
        DesactivarActivarColores();

    }
    void DesactivarActivarColores()
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "SystemPaticule", false);
        des = true;
        puntuacion.text = "0";
        camara.SetActive(false);
        nomorir=false;
        NotificationCenter.DefaultCenter().PostNotification(this, "Desactivar2");
        Enemigos.nomorir = false;
    }
}
