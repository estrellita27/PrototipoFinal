using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelAlien : MonoBehaviour
{
    public void Siguiente_3(){
        SceneManager.LoadScene("Final");
    }

    public void Anterior_3(){
        SceneManager.LoadScene("PantallaSelect");
    }

    public void Logo_3(){
        SceneManager.LoadScene("PantallaPrincipal");
    }

    public void Salir_3(){
        Application.Quit();
    }
}
