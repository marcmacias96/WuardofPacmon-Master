using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float velocidad = 0f;
	public bool enMovimiento = false;
	private float tiempoInicio = 0f;
    public bool pantIniocio=false;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        if(pantIniocio)
        {
            enMovimiento = true;
        }
    }

	void PersonajeHaMuerto(){
		enMovimiento = false;
        Debug.Log("murio");
	}
    
      


	void PersonajeEmpiezaACorrer(){
		enMovimiento = true;
		tiempoInicio = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(enMovimiento){
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(((Time.time - tiempoInicio) * velocidad) % 1, 0);
		}
	}
}
