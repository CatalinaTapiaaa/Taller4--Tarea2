using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciarP : MonoBehaviour
{
    public GameObject componente;
    public Controlador controlador;
    private void Start()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();
        controlador.puntuacion = 0; 
    }
      
}
