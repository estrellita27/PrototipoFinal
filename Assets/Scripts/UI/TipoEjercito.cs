using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TipoEjercito", menuName = "Ejercito")]
public class TipoEjercito : ScriptableObject
{
    public string ejercito = null;
    public int Vida = 0;
    public int Fuerza = 0;
    public int Velocidad = 0;

    public string Descripcion;
    public Sprite Modelo;

    public void setVida(int vida){
        this.Vida = vida;
    }

    public void setFuerza(int fuerza){
        this.Fuerza = fuerza;
    }

    public void setVelocidad(int velocidad){
        this.Velocidad = velocidad;
    }


    
    
}
