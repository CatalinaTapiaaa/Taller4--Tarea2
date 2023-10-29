using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    public SpriteRenderer fondo;
    public Color[] colores;
    [Space]
    public int numero;
    public bool cambiar;

    void Update()
    {
        if (cambiar)
        {
            fondo.color = colores[numero];

            if (numero > colores.Length)
            {
                numero = 0;
            }

            cambiar = false;
        }
    }
}
