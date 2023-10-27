using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform[] puntos;
    [Space]
    public Linea linea;
    public Animator ani;
    public SpriteRenderer lenguaFinal;

    void Start()
    {
        linea.SetUpLine(puntos);
        lenguaFinal.enabled = false;
    }
}
