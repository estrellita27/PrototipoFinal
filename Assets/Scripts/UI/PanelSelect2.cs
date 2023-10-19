using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PanelSelect2 : MonoBehaviour
{
    public void Anterior_4(){
        SceneManager.LoadScene("PantallaSelect1");
    }

    public void Romano_1(){
        SceneManager.LoadScene("PantallaRomano2");
    }

    public void Alien_1(){
        SceneManager.LoadScene("PantallaAlien2");
    }

    public void Logo_4(){
        SceneManager.LoadScene("PantallaPrincipal");
    }

    public void Salir_4(){
        Application.Quit();
    }
}
