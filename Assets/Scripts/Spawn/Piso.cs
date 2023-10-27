using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour
{
    public Derrota derrota;
    public Spawn spawn;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            derrota.derrota = true;
            spawn.desactivar = true;
            Destroy(gameObject);
        }
    }
}
