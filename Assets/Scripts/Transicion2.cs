using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Transicion2 : MonoBehaviour
{
    public GameObject cometa;
    public GameObject componente;
    public Controlador controlador;
    public TextMeshProUGUI punMax;

    private void Start()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();

        punMax.text = controlador.puntacionMax.ToString("BEST 0");
    }

    public void Final()
    {
        cometa.SetActive(true);
        Destroy(gameObject);
    }
}
