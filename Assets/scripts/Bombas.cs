using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombas : MonoBehaviour {
    private Animator animator;
    private bool explo=false,entra=false;
    public float vel;

	// Use this for initialization
	void Start () {
        animator=GetComponent<Animator>();
        
	}

    // Update is called once per frame
    void Update()
    {
        if(entra)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 3+vel);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -vel);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "suelo")
        {
            explo = true;
            animator.SetBool("explo", explo);
            entra = true;
            explo = false;
            GetComponent<Collider2D>().isTrigger = true;

            Invoke("Destruir", 0.5f);
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.SetActive(false);
                NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");

            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player" || other.tag=="suelo")
        {
            explo = true;
            animator.SetBool("explo", explo);
            entra = true;
            explo = false;
            GetComponent<Collider2D>().isTrigger = false;
            
            Invoke("Destruir", 0.5f);
            if (other.tag=="Player")
            {
                other.gameObject.SetActive(false);
                NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
                
            }
        }
            
           
    }
    void Destruir()
    {
        Destroy(gameObject);
        entra = false;
    }
}
