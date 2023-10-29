using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public ParticleSystem efectoMuerte;
    public TextMeshPro numeroActual;
    public int numero;

    public bool de, iz;
    float t;

    void Update()
    {
        numeroActual.text = numero.ToString("0");
        if (de)
        {
            transform.Rotate(0, 0, 180 * Time.deltaTime * 0.5f);
        }
        if (iz)
        {
            transform.Rotate(0, 0, -180 * Time.deltaTime * 0.5f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            if (transform.position.x > 0)
            {
                de = true;
                iz = false;
            }
            else
            {
                de = false;
                iz = true;
            }
        }         

        if (collision.gameObject.CompareTag("Ataque"))
        {
            if (numero == 1)
            {
                Instantiate(efectoMuerte, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(Restar());
            }
            de = false;
            iz = false;
        }     
    }

    // areglar
    IEnumerator Restar()
    {
        transform.localScale = new Vector2(transform.localScale.x - 2, transform.localScale.y - 2);
        numero -= 1;
        yield return null;
    }
}
