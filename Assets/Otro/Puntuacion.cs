using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    public GameObject componente;
    public Controlador controlador;
    public CambiarColor cambiarColor;
    public Items items;
    public Spawn spawn;
    [Space]
    public Animator ani;
    public TextMeshProUGUI punActual;
    public TextMeshProUGUI textoVictoria;
    [Space]
    public float sumarVelocidad;

    int nivel;
    int x = 1;

    bool pasarNivel;

    void Update()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();
        punActual.text = controlador.puntuacion.ToString("0");

        if (spawn.listo)
        {
            GameObject[] items = GameObject.FindGameObjectsWithTag("Item");           

            if (items.Length == 0)
            {
                ani.SetBool("Activar", true);
                nivel++;

                pasarNivel = true;
                spawn.listo = false;
            }
        }
        if (pasarNivel)
        {
            if (nivel == x * 3)
            {
                cambiarColor.numero++;
                x++;
            }
          
            if (nivel == 1)
            {
                spawn.items.Add(items.malo);
            }
            if (nivel == 2)
            {
                spawn.items.Add(items.dos);
            }
            if (nivel == 6)
            {
                spawn.items.Add(items.tres);
            }
            if (nivel == 8)
            {
                spawn.items.Add(items.cuatro);
            }
            if (nivel == 10)
            {
                spawn.items.Add(items.cinco);
            }
            if (nivel == 12)
            {
                spawn.items.Add(items.bueno);
            }
            pasarNivel = false;
        }
    }

    public void DesactivarAniTexto()
    {
        ani.SetBool("Activar", false);
        cambiarColor.cambiar = true;
        spawn.activar = true;
    }
    public void SumarPuntos()
    {
        controlador.puntuacion++;
    }
}
