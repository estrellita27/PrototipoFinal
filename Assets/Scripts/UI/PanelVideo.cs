using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelVideo : MonoBehaviour
{
    public void Saltar(){
        SceneManager.LoadScene("PantallaSelect");
    }

    public void Logo(){
        SceneManager.LoadScene("PantallaPrincipal");
    }

    public void Salir(){
        Application.Quit();
    }
}
