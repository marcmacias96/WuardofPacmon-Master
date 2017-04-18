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
        
            entra = pantalla;
        if (pantalla)
        {
            pantalla = false;
            if (Dere)
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
                
                GetComponent<Animator>().SetBool("dispara", true);
                Invoke("Dispara", 0.2f);
                Invoke("noDispara", 0.1f);
                

            }
            

        }
       

    void Dispara()
    {
        
        Instantiate(disparo, disparador.position, disparador.rotation);  
    }
    void noDispara()
    {
        GetComponent<Animator>().SetBool("dispara", false);
    }
    void Pared(Notification not)
    {
        Debug.Log(not.data+"data");
        if((string)not.data =="ParedIzquierda")
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if((string)not.data== "ParedDerecha")
        {

            GetComponent<SpriteRenderer>().flipX = true;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        animator.SetFloat("velX", GetComponent<Rigidbody2D>().velocity.x);
       
    }
}
