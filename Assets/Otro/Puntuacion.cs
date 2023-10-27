using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    public string[] frasesVictoria;
    [Space]
    public GameObject componente;
    public Controlador controlador;
    public Progresion progresion;
    public Spawn spawn;
    [Space]
    public Animator ani;
    public TextMeshProUGUI punActual;
    public TextMeshProUGUI textoVictoria;
    [Space]
    public float sumarVelocidad;

    int current;

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
                controlador.puntuacion++;
                current++;

                int aleatorio = Random.Range(0, frasesVictoria.Length);
                textoVictoria.text = frasesVictoria[aleatorio];
                ani.SetBool("Activar", true);

                spawn.listo = false;
            }
        }
        spawn.cantidadSpawn = 3;

        if (controlador.puntuacion == 1)
        {
            spawn.cantidadSpawn = 2;
            spawn.items.Add(progresion.malo);
        }
        if (controlador.puntuacion == 2)
        {
            spawn.items.Add(progresion.itemDos);
        }
        if (controlador.puntuacion == 3)
        {
            spawn.cantidadSpawn = 3;
            spawn.items.Add(progresion.itemTres);
        }
        if (controlador.puntuacion == 4)
        {
            spawn.items.Add(progresion.itemCuatro);
        }
        if (controlador.puntuacion == 5)
        {
            spawn.items.Add(progresion.itemCinco);
        }
        if (controlador.puntuacion == 6)
        {
            spawn.items.Add(progresion.bueno);
        }    

        if (controlador.puntuacion == 2 * current)
        {
            spawn.velocidadDisparo += sumarVelocidad;
        }
    }

    public void DesactivarAniTexto()
    {
        ani.SetBool("Activar", false);
    }
}
