using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personajes : MonoBehaviour {

    private string Nombre;
    private int PuntajeDesban;
    private bool ban ;

    public Personajes(string nombre,int puntaje,bool ban)
    {
        this.Nombre = nombre;
        this.PuntajeDesban = puntaje;
        this.ban = ban;
    }

   public void setBan(bool ban)
    {
        this.ban = ban;
    }
    public bool GetBan()
    {
        return this.ban;
    }

}
