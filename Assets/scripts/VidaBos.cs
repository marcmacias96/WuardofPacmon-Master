using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBos : MonoBehaviour {
    public float Vida=100;
    string text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Vida<0)
        {
            Destroy(gameObject);

        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vida -= 5;
        Destroy(collision.gameObject);
        
    }
   
}
