using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PanelAlien : MonoBehaviour
{
    public TipoEjercito Alien1=null;
    public TMP_InputField inVida;
    public TMP_InputField inFuerza;
    public TMP_InputField inVelocidad;
    

    private int vidaAlien1;
    private int fuerzaAlien1;
    private int velocidadAlien1;

    public void inputVida_1(){
        vidaAlien1 = Convert.ToInt32(inVida.text);
        Alien1.setVida(vidaAlien1);
    }

    public void inputFuerza_1(){
        fuerzaAlien1 = Convert.ToInt32(inFuerza.text);
        Alien1.setFuerza(fuerzaAlien1);
    }

    public void inputVelocidad_1(){
        velocidadAlien1 = Convert.ToInt32(inVelocidad.text);
        Alien1.setVelocidad(velocidadAlien1);
    }

    public void Siguiente_3(){
        SceneManager.LoadScene("PantallaSelect2");
    }
    public void Siguiente_6(){
        SceneManager.LoadScene("Final");
    }

    public void Anterior_3(){
        SceneManager.LoadScene("PantallaSelect");
    }

    public void Anterior_6(){
        SceneManager.LoadScene("PantallaSelect2");
    }

    public void Logo_3(){
        SceneManager.LoadScene("PantallaPrincipal");
    }

    public void Salir_3(){
        Application.Quit();
    }
}
