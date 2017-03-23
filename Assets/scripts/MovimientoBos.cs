using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBos : MonoBehaviour {
    [Header("Bombardeo")]
    public GameObject Bombas;
    public Transform disparador;
    public float fireRate;
    public float nexFire = 0;
    [Header("Movimiento")]
    public float velocidad2;
    public float rate;
    public static bool pantalla = false;
    public bool entra = false;
    public static bool Dere, dispara;
    private float nextChange;
    
    // Use this for initialization
    void Start () {
		
	}
 
    // Update is called once per frame
    void Update () {
        entra = pantalla;
        if (pantalla && Time.time > nextChange)
        {
            nextChange = Time.time + rate;
            pantalla = false;
            if (Dere)
            {
                Dere = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad2, GetComponent<Rigidbody2D>().velocity.y);

                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                Dere = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad2, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if( Time.time > nexFire)
        {
            nexFire = Time.time + fireRate;
            Instantiate(Bombas, disparador.position, disparador.rotation);
        }
       

    }

}
