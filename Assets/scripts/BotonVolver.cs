using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVolver : MonoBehaviour {
    public GameObject Camara;
    // Use this for initialization
    void Start () {
		
	}
    void OnMouseDown()
    {
        Camara.SetActive(false);
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
