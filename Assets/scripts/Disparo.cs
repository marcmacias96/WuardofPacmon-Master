using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour {
    private Rigidbody2D rig;
    public float speed=1;
	// Use this for initialization
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }
	void Start () {
        rig.velocity = transform.up* speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
