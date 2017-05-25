using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float fuerzaSalto; //Velocidad de movimiento
    public static float velo = 26.5f;
    public  float velocidad;
    public bool enSuelo = true;
    public Transform comprobadorSuelo = null;
    private float comprobadorRadio = 0.07f;
    public LayerMask mascaraSuelo;
    private Animator animator;
    private bool corriendo = false;
    public bool pantInicio = false;
    public bool dobleSalto = false;
    private bool muerto=false;
    public GameObject SystemPArticulas;
    private Vector2 touchOrigin = -Vector2.one;
    
    void Start()
    {
        SystemPArticulas.SetActive(false);
        NotificationCenter.DefaultCenter().AddObserver(this, "AumentarVelocidad");
        NotificationCenter.DefaultCenter().AddObserver(this, "SystemPaticule");
        NotificationCenter.DefaultCenter().AddObserver(this, "Quieto");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        if (pantInicio)
        {
            corriendo = true;
            enSuelo = true;

        }
    }
    void PersonajeHaMuerto()
    {
        muerto = true;
    }
    void Quieto()
    {
        velocidad = 0;
        fuerzaSalto = 0;
    }
    void SystemPaticule(Notification not)
    {
        SystemPArticulas.SetActive((bool)not.data);
    }
    void AumentarVelocidad()
    {
        if(velocidad<20)
        {
            velocidad += 1.4f;
            NotificationCenter.DefaultCenter().PostNotification(this, "gen");
        }
        

    }
    // Update is called once per frame
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
    
        if (corriendo)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad ,GetComponent<Rigidbody2D>().velocity.y);
        }
        animator.SetFloat("velX", GetComponent<Rigidbody2D>().velocity.x);
        enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
        animator.SetBool("isGrounded", enSuelo);
        if (enSuelo)
        {
            dobleSalto = false;
        }

    }
    void Update() {
        if (Input.GetMouseButtonDown(0)||pantInicio)
        {
            if (corriendo)
            {
                if(!pantInicio)
                {
                    if (enSuelo || !dobleSalto )
                    {
                        // Hacemos que salte si puede saltar
                        if (!muerto)
                        {
                            GetComponent<AudioSource>().Play();
                            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
                            if (!dobleSalto && !enSuelo)
                            {
                                dobleSalto = true;
                            }
                        }
                        else
                        {
                            Debug.Log("ya no debe saltar");
                        }
                        
                    }
                }
               
                
            }
            else
            {
                corriendo = true;
                NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
               

            }
        }
       
        }
    } 