using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigo2 : MonoBehaviour {

    public GameObject[] obj;
    public float tiempoMin = 1.25f;
    public float tiempoMax = 2.5f;
    public bool fin = false;
    public int num;
    public static GeneradorEnemigo2 gene2;
    public string nombre;
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "GenerarEnemigo2");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        NotificationCenter.DefaultCenter().AddObserver(this, "gen");


    }
    void gen()
    {
        tiempoMin -= 0.15f;
        tiempoMax -= 0.15f;
    }
    void GenerarEnemigo2(Notification notificacion)
    {
        Generar();
        
    }


    void PersonajeHaMuerto()
    {
        fin = true;
        if(obj[num].name=="gemidos")
        {
            GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generar()
    {
        if (!fin)
        {
             num = Random.Range(0, obj.Length);
            Instantiate(obj[num], transform.position, Quaternion.identity);
            nombre = obj[num].name;
            Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
        }

    }
}
