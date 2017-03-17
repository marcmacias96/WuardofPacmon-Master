using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAred : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "Pared",name);
        Debug.Log("Choco con " + name);
       
    }
}
