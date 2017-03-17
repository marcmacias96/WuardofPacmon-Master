using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float fuerzaSalto = 10.0F; //Velocidad de movimiento
    public float velocidad = 1f;
    public bool enSuelo = true;
    public Transform comprobadorSuelo = null;
    private float comprobadorRadio = 0.07f;
    public LayerMask mascaraSuelo;
    private Animator animator;
    private bool corriendo = false;
    public bool pantInicio = false;
    public bool dobleSalto = false;
    public GameObject SystemPArticulas;

    void Start()
    {
        SystemPArticulas.SetActive(false);
        NotificationCenter.DefaultCenter().AddObserver(this, "AumentarVelocidad");
        NotificationCenter.DefaultCenter().AddObserver(this, "SystemPaticule");
        if (pantInicio)
        {
            corriendo = true;
            enSuelo = true;

        }
    }
    void SystemPaticule(Notification not)
    {
        SystemPArticulas.SetActive((bool)not.data);
    }
    void AumentarVelocidad()
    {
        if(velocidad<19)
        {
            velocidad += 1f;
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
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
                    if (enSuelo || !dobleSalto)
                    {
                        // Hacemos que salte si puede saltar
                        GetComponent<AudioSource>().Play();
                        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
                        //rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
                        if (!dobleSalto && !enSuelo)
                        {
                            dobleSalto = true;
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