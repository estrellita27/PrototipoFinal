using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TipoEjercito", menuName = "Ejercito")]
public class TipoEjercito : ScriptableObject
{
    public string ejercito;
    public int Vida;
    public int Fuerza;
    public int Velocidad;

    public string Descripcion;
    public Sprite Modelo;


    
    
}
