using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public TipoEjercito tipoEjercito = null;

    public TextMeshProUGUI ejercitotext = null;
    public TextMeshProUGUI vidatext = null;
    public TextMeshProUGUI fuerzatext = null;
    public TextMeshProUGUI velocidadtext = null;
    public TextMeshProUGUI descriptiontext = null;

    public Image modeloImage = null;


    void Start()
    {
        ejercitotext.text = tipoEjercito.ejercito;
        vidatext.text = tipoEjercito.Vida.ToString();
        fuerzatext.text = tipoEjercito.Fuerza.ToString();
        velocidadtext.text = tipoEjercito.Velocidad.ToString();
        descriptiontext.text = tipoEjercito.Descripcion;

        modeloImage.sprite = tipoEjercito.Modelo;
    }

}
