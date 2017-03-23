using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPersonaje : MonoBehaviour {
    private string nombre;
    private Animator anima;
    public bool select,inactivo=true;
    public string etiqueta;
    
    public GameObject[] personajes;
    // Use this for initialization
    void Awake()
    {
        anima = GetComponent<Animator>();
    }
    void Start()
    {
        for (int i = 0; i < personajes.Length; i++)
        {
            switch(personajes[i].tag)
            { 
                case "MEXICANO":
                    personajes[i].GetComponent<Animator>().SetBool("Ban", Manager.mexicano.GetBan());
                    etiqueta = "MEx";
                break;

                case "PERUANO":
                    personajes[i].GetComponent<Animator>().SetBool("Ban", Manager.peruano.GetBan());
                break;

                case "COLOMBIANO":
                    personajes[i].GetComponent<Animator>().SetBool("Ban", Manager.colombiano.GetBan());
                break;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void Deselecsionar()
    {
        anima.SetBool("inactivo", inactivo);
    }
    void OnMouseDown()
    {
        inactivo = false;
        GetComponent<AudioSource>().Play();
        anima.SetBool("inactivo", inactivo);
        nombre = GetComponent<Collider2D>().tag;    
        Debug.Log(nombre);
        EstadoJuego.estadoJuego.jugador = nombre;

        if(!select)
        {
            select = true;
            anima.SetBool("Select", select);
            
            for(int i =0;i<personajes.Length;i++)
            {
               
                Debug.Log(personajes.Length);
                if (!personajes[i].tag.Equals(tag))
                {
                    Debug.Log(personajes[i].tag);
                    personajes[i].GetComponent<SelectPersonaje>().inactivo = true;
                    personajes[i].GetComponent<SelectPersonaje>().select = false;
                    personajes[i].GetComponent<SelectPersonaje>().Deselecsionar();

                }
            }
        }
        else
        {
            anima.SetBool("Select", select);
            select = false;
            
        }
       
        
    }
   
}
