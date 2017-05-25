using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraColores : MonoBehaviour {
    public Material[] materials;//Allows input of material colors in a set size of array;
    public Renderer Rend; //What are we rendering? Input object(Sphere,Cylinder,...) to render.
    private int index = 1;//Initialize at 1, otherwise you have to press the ball twice to change colors at first.
                          // Use this for initialization
    public bool inicio=true;
    public GameObject camara;
    public bool entra=false;
    public GameObject mainCamara;
    public Material Default;
    public static CamaraColores camaracolores;
    void Start()
    {
        
        Rend = GetComponent<Renderer>();//Gives functionality for the renderer
        Rend.enabled = true;//Makes the rendered 3d object visable if enabled;
        //sonido();

    }
    void Update()
    {
        if(inicio)
        {
            sonido();
        }
        if(entra)
        {
            Colores();

        }

    }
    
    void Colores()
    { 
        if (materials.Length == 0)//If there are no materials nothing happens.
            return;
        
            index += 1;//When mouse is pressed down we increment up to the next index location
            if (index == materials.Length + 1)//When it reaches the end of the materials it starts over.
                index = 1;
           // print(index);//used for debugging
            Rend.sharedMaterial = materials[index -1]; //This sets the material color values inside the index

    }
   public  void sonido()
    {
        inicio = false;
        mainCamara.GetComponent<AudioSource>().Pause();
        GetComponent<AudioSource>().Play();
        Invoke("Activar", GetComponent<AudioSource>().clip.length);
        print(GetComponent<AudioSource>().clip.length);
    }
    void Activar()
    {
        entra = true;
        camara.GetComponent<AudioSource>().Play();
        Invoke("Desactivar", camara.GetComponent<AudioSource>().clip.length);
        print("seActivo la camara colores");
        
    }
    void Desactivar()
    {
        
        entra = false;
        Rend.sharedMaterial = Default;
        camara.SetActive(false);
        NotificationCenter.DefaultCenter().PostNotification(this, "DesactivarActivarColores");
        mainCamara.GetComponent<AudioSource>().Play();
        print("Se Desactivo la camara colores");
        inicio = true;
        
    }
    
}
