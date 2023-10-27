using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    //public ParticleSystem muerte;
    public TextMeshPro numeroActual;
    public int numero;

    bool hit;

    void Update()
    {
        numeroActual.text = numero.ToString("0");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ataque"))
        {
            if (numero == 1)
            {
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(Restar());
            }
        }     
    }

    // areglar
    IEnumerator Restar()
    {
        transform.localScale = new Vector2(transform.localScale.x - 1 * 1, transform.localScale.y - 1 * 1);
        numero -= 1;
        yield return null;
    }
}
