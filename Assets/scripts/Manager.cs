using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    ArrayList personajes = new ArrayList();
    
    public static  Personajes peruano = new Personajes("ECUATORIANO", 500, true);
    public static Personajes colombiano = new Personajes("ECUATORIANO", 500, true);
    public static Personajes mexicano = new Personajes("ECUATORIANO", 500, true);
    public static Manager manager;
    void Awake()
    {

       
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {

        
        if (PlayerPrefs.HasKey("Mex"))
        {
            mexicano.setBan(bool.Parse(PlayerPrefs.GetString("Mex")));
        }
        else
        {
            PlayerPrefs.SetString("Mex", "true");
        }
        if (PlayerPrefs.HasKey("Peru"))
        {
            peruano.setBan(bool.Parse(PlayerPrefs.GetString("Peru")));
        }
        else
        {
            PlayerPrefs.SetString("Peru", "true");
        }
        if (PlayerPrefs.HasKey("Colo"))
        {
            colombiano.setBan(bool.Parse(PlayerPrefs.GetString("Colo")));
        }
        else
        {
            PlayerPrefs.SetString("Colo", "true");
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
