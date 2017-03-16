using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPAuse : MonoBehaviour {

    public GameObject camaraPause;
    // Use this for initialization
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "ActivarPause");
    }

    void ActivarPause()
    {
        camaraPause.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
