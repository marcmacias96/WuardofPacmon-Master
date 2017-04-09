using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAred : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Choco con " + name);
        if (other.collider.tag == "Bos")
        {
            MovimientoBos.pantalla = true;
            NotificationCenter.DefaultCenter().PostNotification(this, "LineaBomas");
        }
        else
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "Pared", name);
        }
    }
}
