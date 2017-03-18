using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotJugarBalnco : MonoBehaviour {
    public string nombre=null;
    public TextMesh mensaje;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    void OnMouseDown()
    {
        nombre = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>().jugador;
        Camera.main.GetComponent<AudioSource>().Stop();
        //GetComponent<AudioSource>().Play();
        if (nombre == null || nombre == "")
        {
            mensaje.text = "Selecciona Uno";
        }
        else
        {
            GetComponent<AudioSource>().Play();
            Invoke("CargarNivelJuego", GetComponent<AudioSource>().clip.length);
           
        }
        
        
    }
    void CargarNivelJuego()
    {
        
        
            SceneManager.LoadScene(1);

       
    }
}
