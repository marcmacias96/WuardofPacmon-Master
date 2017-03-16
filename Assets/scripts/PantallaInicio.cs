using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaInicio : MonoBehaviour {
    private bool corriendo=false;
    private Animator animator;
    private float velocidad = 8;
    public bool enSuelo = true;
    private bool salto=false;
   

    // Use this for initialization
    void Start () {
       
    }
   

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
        
        animator.SetBool("isGrounded", enSuelo);

    }
    // Update is called once per frame
    void Update () {
        corriendo = true;
        //NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
       
    }
    void OnMouseDown()
    {
       

      

    }
}
