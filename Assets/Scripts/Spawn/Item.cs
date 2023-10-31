using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    [Header("Sonidos")]
    public AudioSource audioColision;
    [SerializeField] private AudioClip audioMuerte;
    [Space]
    public ParticleSystem efectoMuerte;
    public TrailRenderer cola;
    public TextMeshPro numeroActual;
    public int numero;

    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        numeroActual.text = numero.ToString("0");
    }
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
            if (numero == 1)
            {
                Instantiate(efectoMuerte, transform.position, Quaternion.identity);
                Sonido.Instance.EjecutarSonido(audioMuerte);
                Destroy(gameObject);
            }
            else
            {
                audioColision.Play();
                StartCoroutine(Restar());
            }
        }     
    }

    // areglar
    IEnumerator Restar()
    {
        cola.startWidth -= 0.2f;
        transform.localScale = new Vector2(transform.localScale.x - 1, transform.localScale.y - 1);
        rb2D.gravityScale += 0.1f;
        numero -= 1;
        yield return null;
    }
}
