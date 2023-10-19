using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PanelRomano : MonoBehaviour
{
    public TipoEjercito Romanos1=null;
    public TMP_InputField inVida;
    public TMP_InputField inFuerza;
    public TMP_InputField inVelocidad;
    

    private int vidaRomano1;
    private int fuerzaRomano1;
    private int velocidadRomano1;

    public void inputVida(){
        vidaRomano1 = Convert.ToInt32(inVida.text);
        Romanos1.setVida(vidaRomano1);
    }

    public void inputFuerza(){
        fuerzaRomano1 = Convert.ToInt32(inFuerza.text);
        Romanos1.setFuerza(fuerzaRomano1);
    }

    public void inputVelocidad(){
        velocidadRomano1 = Convert.ToInt32(inVelocidad.text);
        Romanos1.setVelocidad(velocidadRomano1);
    }
    

    public void Siguiente_2(){
        SceneManager.LoadScene("PantallaSelect2");    
    }   

    public void Siguiente_5(){
        SceneManager.LoadScene("Final");
    }


    public void Anterior_2(){
        SceneManager.LoadScene("PantallaSelect");
    }

    public void Anterior_5(){
        SceneManager.LoadScene("PantallaSelect2");
    }

    public void Logo_2(){
        SceneManager.LoadScene("PantallaPrincipal");
    }

    public void Salir_2(){
        Application.Quit();
    }
}
