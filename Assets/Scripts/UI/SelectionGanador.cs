using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectionGanador : MonoBehaviour
{
    public TipoEjercito tipoEjercito = null;

    public TextMeshProUGUI vidatext = null;
    public TextMeshProUGUI fuerzatext = null;
    public TextMeshProUGUI velocidadtext = null;


    void Start()
    {
        vidatext.text = tipoEjercito.Vida.ToString();
        fuerzatext.text = tipoEjercito.Fuerza.ToString();
        velocidadtext.text = tipoEjercito.Velocidad.ToString();
    }

}
