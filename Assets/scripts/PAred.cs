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
        if (other.collider.tag == "Bos"|| other.collider.tag=="meemperra")
        {
            MovimientoBos.pantalla = true;
            NotificationCenter.DefaultCenter().PostNotification(this, "LineaBomas");
        }
        else
        {
            if(other.collider.tag=="Bombas")
            {
                Destroy(gameObject);
            }
            NotificationCenter.DefaultCenter().PostNotification(this, "Pared", name);
        }
    }
}
