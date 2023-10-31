using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malo : MonoBehaviour
{
    [Header("Sonidos")]
    public AudioSource audioColision;

    void OnCollisionEnter2D(Collision2D collision)
    {    
        if (collision.gameObject.CompareTag("Pared"))
        {
            audioColision.Play();
        }
        if (collision.gameObject.CompareTag("Item"))
        {
            audioColision.Play();
        }
        if (collision.gameObject.CompareTag("Malo"))
        {
            audioColision.Play();
        }
        if (collision.gameObject.CompareTag("Bueno"))
        {
            audioColision.Play();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MatarMalo"))
        {
            Destroy(gameObject);
        }
    }
}
