using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour
{
    [SerializeField] private AudioClip audioMuerte;
    public Derrota derrota;
    public Ataque ataque;
    public Spawn spawn;
    public bool muerte;

    void Update()
    {
        if (muerte)
        {
            derrota.derrota = true;
            ataque.stop = true;
            spawn.desactivar = true;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Sonido.Instance.EjecutarSonido(audioMuerte);

            muerte = true;           
        }
    }   
}
