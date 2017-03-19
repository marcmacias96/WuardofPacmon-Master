using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPakVsBos : MonoBehaviour {
    public static Animator animator;
    public bool entra = false;
    [Header("Disparo")]
    public GameObject disparo;
    public Transform disparador;
    public float fireRate;
    public float nexFire = 0;
    [Header("Movimiento1")]
    public GameObject derecha;
    public GameObject izquierda;
    public float velocidad=1;
    public static bool dere;
    public static bool izq;
    private bool desactivaIzq = true;
    private bool desactivaDere = true;
    public bool Mov1;

    [Header("Movomiento 2")]
    public float velocidad2;
    public static bool Dere,dispara;
    public static bool pantalla = false;
    // Use this for initialization
    void Start () {
        dere = false;
        izq = false;
        dispara = false;
        NotificationCenter.DefaultCenter().AddObserver(this, "Pared");
    }
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () {
        if(Mov1)
        {
            if (dere && desactivaDere)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
                animator.SetFloat("velX", GetComponent<Rigidbody2D>().velocity.x);
                GetComponent<SpriteRenderer>().flipX = false;
                desactivaIzq = true;
            }
            if (izq && desactivaIzq)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad, GetComponent<Rigidbody2D>().velocity.y);
                animator.SetFloat("velX", -GetComponent<Rigidbody2D>().velocity.x);
                GetComponent<SpriteRenderer>().flipX = true;
                desactivaDere = true;
            }
            if (Input.GetMouseButtonDown(0) && Time.time > nexFire)
            {
                nexFire = Time.time + fireRate;
                Instantiate(disparo, disparador.position, disparador.rotation);
            }
        }
        else
        {
            entra = pantalla;
            if(pantalla)
            {
                pantalla = false;
                if(Dere)
                {
                    Dere = false;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad2, GetComponent<Rigidbody2D>().velocity.y);
                    animator.SetFloat("velX", GetComponent<Rigidbody2D>().velocity.x);
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    Dere = true;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad2, GetComponent<Rigidbody2D>().velocity.y);
                    animator.SetFloat("velX", -GetComponent<Rigidbody2D>().velocity.x);
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            if(dispara && Time.time > nexFire)
            {
                dispara = false;
                nexFire = Time.time + fireRate;
                Instantiate(disparo, disparador.position, disparador.rotation);

            }

        }
       
	}
    void Pared(Notification not)
    {
        Debug.Log(not.data+"data");
        if((string)not.data =="ParedIzquierda")
        {
            desactivaIzq = false;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if((string)not.data== "ParedDerecha")
        {
            desactivaDere = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        izq = false;
        dere = false;
        Debug.Log("Entro");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        animator.SetFloat("velX", GetComponent<Rigidbody2D>().velocity.x);
       
    }
}
