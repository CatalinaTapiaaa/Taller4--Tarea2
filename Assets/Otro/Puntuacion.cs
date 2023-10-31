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
    public Animator aniTutorial;
    public TextMeshProUGUI punActual;
    public TextMeshProUGUI punActualMenu;
    public TextMeshProUGUI punMax;
    public TextMeshProUGUI punMax2;
    public TextMeshProUGUI textoVictoria;
    [Space]
    public float restarTiempoDisparo;

    int nivel;
    int x = 1;

    bool pasarNivel;

    void Update()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();

        punActual.text = controlador.puntuacion.ToString("0");
        punActualMenu.text = controlador.puntuacion.ToString("0");
        punMax.text = controlador.puntacionMax.ToString("BEST 0");
        punMax2.text = controlador.puntacionMax.ToString("BEST 0");


        if (spawn.listo)
        {
            GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
            GameObject[] malos = GameObject.FindGameObjectsWithTag("Malo");

            if (malos.Length == 0)
            {
                if (items.Length == 0)
                {
                    ani.SetBool("Activar", true);
                    nivel++;

                    pasarNivel = true;
                    spawn.listo = false;
                }
            }          
        }
        if (pasarNivel)
        {
            if (nivel == x * 3)
            {
                if (spawn.tiempoSpawn > 0.5f)
                {
                    spawn.tiempoSpawn -= restarTiempoDisparo;
                }
                
                cambiarColor.numero++;
                x++;
            }
            spawn.activar = true;

            //Uno
            if (nivel == 1)
            {
                aniTutorial.SetBool("Quitar", true);
                spawn.items.Add(items.maloUno);
            }
            //Dos
            if (nivel == 2)
            {
                spawn.items.Add(items.itemDos);
            }
            if (nivel == 3)
            {
                spawn.items.Add(items.maloDos);
            }
            //Tres
            if (nivel == 4)
            {
                spawn.items.Add(items.itemTres);
            }
            if (nivel == 5)
            {
                spawn.items.Add(items.maloTres);
            }
            //Cuatro
            if (nivel == 6)
            {
                spawn.items.Add(items.itemCuatro);
            }
            if (nivel == 7)
            {
                spawn.items.Add(items.maloCuatro);
            }
            //Cinco
            if (nivel == 8)
            {
                spawn.items.Add(items.itemCinco);
            }
            if (nivel == 9)
            {
                spawn.items.Add(items.maloCinco);
            }
            //Seis
            if (nivel == 10)
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
    }
    public void SumarPuntos()
    {
        controlador.puntuacion++;
    }
}
