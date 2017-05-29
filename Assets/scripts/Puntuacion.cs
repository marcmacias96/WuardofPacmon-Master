using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Puntuacion : MonoBehaviour {

    public  int puntuacion = 0, paks = 0, packsanim =0;
	public TextMesh marcador;
    public TextMesh marcadorPaks;
    public GameObject geneEnemigos2;
    public GameObject geneEnemigos3;
    public GameObject camaraPasarNivel;
    private bool entra=false;

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
        packsanim ++;
        
        AnimMarcPacks.anim.SetInteger("packs", packsanim);
        if (packsanim==3)
            {
                Invoke("CambAnim", 0.5f);
            }

        
        ActualizarMarcador();
    }
    void CambAnim()
    {
        
        packsanim = 0;
        AnimMarcPacks.anim.SetInteger("packs", packsanim);
        
    }
    void PersonajeHaMuerto(Notification notificacion){
        int suma=puntuacion;
		if(puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima){
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar();   
        }
       if(!entra)
        {
            entra = true;
            if (PlayerPrefs.HasKey("SumatoriaPuntuacion"))
            {
                suma += PlayerPrefs.GetInt("SumatoriaPuntuacion", puntuacion);
                PlayerPrefs.SetInt("SumatoriaPuntuacion", suma);
            }
            else
            {
                PlayerPrefs.SetInt("SumatoriaPuntuacion", suma);
            }
            Debug.Log("La Sumatoria de los nikes es:" + suma);
        }
    }

	void IncrementarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion+=puntosAIncrementar;
		ActualizarMarcador();
	}
    void Pausa()
    {
        Time.timeScale = 0;
    }
	void ActualizarMarcador(){
        if(puntuacion!=0)
        {
            if (puntuacion % 10 ==0)
            {
                NotificationCenter.DefaultCenter().PostNotification(this, "AumentarVelocidad");
            }
            
        }
        if(puntuacion==100)
        {
            camaraPasarNivel.SetActive(true);
            Invoke("Pausa", 0.8f);
            
            if (puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima)
            {
                EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
                EstadoJuego.estadoJuego.Guardar();
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
