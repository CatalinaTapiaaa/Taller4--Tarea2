using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicion : MonoBehaviour
{
    public Ataque ataque;
    public Spawn spawn;

    public void Play()
    {
        ataque.stop = false;
        spawn.desactivar = false;
        Destroy(gameObject);
    }
}
