using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	public int puntuacion = 0,paks=0;
	public TextMesh marcador;
    public TextMesh marcadorPaks;
    public GameObject geneEnemigos2;
    public GameObject geneEnemigos3;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPaks");

        ActualizarMarcador();
	}
	void IncrementarPaks(Notification notificacion)
    {
        int puntosAIncrementar = (int)notificacion.data;
        paks += puntosAIncrementar;
        ActualizarMarcador();
    }

    void PersonajeHaMuerto(Notification notificacion){
		if(puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima){
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar();
		}
	}

	void IncrementarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion+=puntosAIncrementar;
		ActualizarMarcador();
	}

	void ActualizarMarcador(){
        if(puntuacion!=0)
        {
            if (puntuacion % 10 ==0)
            {
                NotificationCenter.DefaultCenter().PostNotification(this, "AumentarVelocidad");
            }
            
        }
        marcadorPaks.text = paks.ToString();

        marcador.text = puntuacion.ToString();
        if(puntuacion==50)
        {
            geneEnemigos2.SetActive(true);
            NotificationCenter.DefaultCenter().PostNotification(this, "GenerarEnemigo2");
        }
        if(puntuacion==75)
        {
            geneEnemigos3.SetActive(true);
            NotificationCenter.DefaultCenter().PostNotification(this, "GenerarEnemigo3");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
