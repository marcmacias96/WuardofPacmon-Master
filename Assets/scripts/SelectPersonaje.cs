using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SelectPersonaje : MonoBehaviour {
    public GameObject Ecuatoriano;
    public GameObject Peruano;
    public TextMesh nombrePerso;
    public bool ecu = true, peru = true;
    private string nombre;
    // Use this for initialization
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "SeleccionPeronajes");
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void SeleccionPeronajes()
    {
        
        if (nombre == "Ecuatoriano")
        {
            //Peruano.SetActive(false);
            peru = false;
            
        }
        else
        {
            if (nombre=="Peruano")
            {
                //Ecuatoriano.SetActive(false);
                ecu = false;
            }
        }
        
    }
    void OnMouseDown()
    {
       
        GetComponent<AudioSource>().Play();
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 20);
        nombre = GetComponent<Collider2D>().tag;
        nombrePerso.text = nombre;
        EstadoJuego.estadoJuego.jugador = nombre;
        NotificationCenter.DefaultCenter().PostNotification(this, "SeleccionPeronajes");
        
    }
   
}
