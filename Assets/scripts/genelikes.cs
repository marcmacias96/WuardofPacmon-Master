using UnityEngine;
using System.Collections;

public class genelikes : MonoBehaviour
{

    public GameObject[] obj;
    public float tiempoMin = 1.25f;
    public float tiempoMax = 2.5f;
    private bool fin = false;
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        NotificationCenter.DefaultCenter().AddObserver(this, "AumentarVelocidad");
    }
    void AumentarVelocidad()
    {
        //tiempoMin += 0.2f;
        //tiempoMax += 0.2f;
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

