using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{

    public TipoEjercito tipoEjercito = null;

    public TextMeshProUGUI ejercitotext = null;
    public TextMeshProUGUI descriptiontext = null;

    public Image modeloImage = null;


    void Start()
    {
        ejercitotext.text = tipoEjercito.ejercito;
        descriptiontext.text = tipoEjercito.Descripcion;

        modeloImage.sprite = tipoEjercito.Modelo;
    }

}
