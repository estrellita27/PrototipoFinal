using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelRomano : MonoBehaviour
{
    public void Siguiente_2(){
        SceneManager.LoadScene("PantallaAlien");
    }

    public void Anterior_2(){
        SceneManager.LoadScene("PantallaSelect");
    }

    public void Logo_2(){
        SceneManager.LoadScene("PantallaPrincipal");
    }

    public void Salir_2(){
        Application.Quit();
    }
}
