using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelResultados : MonoBehaviour
{

    public void inicio(){
        SceneManager.LoadScene("PantallaSelect");
    }

    public void Logo_4(){
        SceneManager.LoadScene("PantallaPrincipal");
    }

    public void Salir_4(){
        Application.Quit();
    }
}
