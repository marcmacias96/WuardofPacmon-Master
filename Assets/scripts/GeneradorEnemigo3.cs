using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigo3 : MonoBehaviour {

    public GameObject[] obj;
    public float tiempoMin = 1.25f;
    public float tiempoMax = 2.5f;
    public bool fin = false;
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "GenerarEnemigo3");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        NotificationCenter.DefaultCenter().AddObserver(this, "gen");

    }
    void gen()
    {
        tiempoMin -= 0.15f;
        tiempoMax -= 0.15f;
    }
    void GenerarEnemigo3(Notification notificacion)
    {
        Generar();
    }

    void PersonajeHaMuerto()
    {
        fin = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Generar()
    {
        if (!fin)
        {
            Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
            Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
        }

    }
}
