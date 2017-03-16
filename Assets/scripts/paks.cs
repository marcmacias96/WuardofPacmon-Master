using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paks : MonoBehaviour {

    public int puntosGanados = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPaks", puntosGanados);
            Destroy(gameObject);
        }

    }
}
