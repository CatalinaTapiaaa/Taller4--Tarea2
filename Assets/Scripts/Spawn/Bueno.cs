using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bueno : MonoBehaviour
{
    [Header("Sonidos")]
    public AudioSource audioColision;
    [SerializeField] private AudioClip audioMuerte;
    public ParticleSystem efectoMuerte;

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

        if (collision.gameObject.CompareTag("Ataque"))
        {
            Instantiate(efectoMuerte, transform.position, Quaternion.identity);
            Sonido.Instance.EjecutarSonido(audioMuerte);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Matar"))
        {
            Destroy(gameObject);
        }
    }
}
