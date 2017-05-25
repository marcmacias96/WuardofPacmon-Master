using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarColores : MonoBehaviour {
    public TextMesh puntuacion;
    public GameObject camara;
    public static bool nomorir = false;
    private bool entra=false;
    private float mod=1;
    private int numAct=0;
    // Use this for initialization
    void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "DesactivarActivarColores");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
       
    }
	
	// Update is called once per frame
	void Update () {
        
        if(int.Parse(puntuacion.text)!=numAct)
        {
            numAct = int.Parse(puntuacion.text);
            mod = int.Parse(puntuacion.text) % 3;
        }
        
        if (mod==0&&!entra)
        {
            entra = true;
            nomorir = true;
            camara.SetActive(true);
            NotificationCenter.DefaultCenter().PostNotification(this, "SystemPaticule",true);
            
            print("Entro en la funcion Activar camara");
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
        entra = false;
        camara.SetActive(false);
        mod = 1;
        NotificationCenter.DefaultCenter().PostNotification(this, "Desactivar2");
        Enemigos.nomorir = false;
        nomorir = false;
        print("SE desactivo La camara y no morir");
    }
}
