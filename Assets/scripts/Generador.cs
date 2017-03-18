using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

	public GameObject[] obj;
	public float tiempoMin = 1.25f;
	public float tiempoMax = 2.5f;
    public int num, indice;
    public string nombre;
    private bool fin = false;
    public string nom;
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        NotificationCenter.DefaultCenter().AddObserver(this, "gen");
        
    }
    void gen()
    {
        tiempoMin -= 0.18f;
        tiempoMax-=0.18f;
    }
    void PersonajeEmpiezaACorrer(Notification notificacion)
    {
        Generar();
    }
    
    void PersonajeHaMuerto()
    {
        fin = true;
        
    }

    // Update is called once per frame
    void Update () {
	
	}

	void Generar(){
        if(!fin)
        {
            indice = Random.Range(0, obj.Length);
            Instantiate(obj[indice], transform.position, Quaternion.identity);
            nom = obj[indice].tag;
            if (obj[indice].tag=="gemido")
            {
                nom = obj[indice].tag;
            }
            
            Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
        }
		
	}
}
