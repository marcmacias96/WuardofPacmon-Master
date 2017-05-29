using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesInicio : MonoBehaviour {

	public void BotonSalir()
    {
        Application.Quit();
    }
    public void Ok()
    {
        SceneManager.LoadScene(1);
        
    }
    public void pasarJefe1()
    {
        SceneManager.LoadScene(3);
    }
}
