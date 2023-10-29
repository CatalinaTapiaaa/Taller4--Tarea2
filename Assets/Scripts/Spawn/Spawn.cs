using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] pivotsMover;
    public Transform[] pivotsRotar;
    public List<GameObject> items = new List<GameObject>();
    [Space]
    public AnimationCurve curva;
    public ParticleSystem particula;
    public Animator ani;
    public Image barra;
    public Transform cañon;
    public Transform pivotSpawn;
    [Space]
    public float velocidadMovimiento;
    public float velocidadDisparo;
    public float tiempoSpawn;
    public int cantidadSpawn;
    [Space]
    public bool activar;
    public bool  desactivar;
    public bool listo;

    bool enPosicion, spawn, rotar, disparar, reiniciar;
    float t, tiempo;
    int current, aleatorioRotacion;

    void Start()
    {
        particula.Stop();
        tiempo = tiempoSpawn;
        enPosicion = true;
    }

    void Update()
    {
        if (!desactivar)
        {
            if (activar)
            {
                int aleatorioMover = Random.Range(0, pivotsMover.Length);
                aleatorioRotacion = Random.Range(0, pivotsRotar.Length);
                tiempo = tiempoSpawn;

                StartCoroutine(MoverCañon(cañon.position, pivotsMover[aleatorioMover].position, velocidadMovimiento));
                rotar = true;
                activar = false;
                reiniciar = false;
            }
            if (enPosicion)
            {
                t += Time.deltaTime;
                if (t >= 0.5f)
                {
                    t = 0;
                    spawn = true;
                    enPosicion = false;
                }
            }

            if (spawn)
            {
                if (!reiniciar)
                {
                    tiempo -= Time.deltaTime;
                    if (tiempo <= 0)
                    {
                        StartCoroutine(CañonSpawn());
                        reiniciar = true;
                    }
                }
                if (reiniciar)
                {
                    tiempo += Time.deltaTime * 2;
                    if (tiempo >= tiempoSpawn)
                    {
                        reiniciar = false;
                    }
                }
            }                

            if (current >= cantidadSpawn)
            {
                StopAllCoroutines();
                current = 0;
                listo = true;
                spawn = false;
            }
            if (rotar)
            {
                Vector2 direccion = pivotsRotar[aleatorioRotacion].position - cañon.position;
                cañon.up = direccion * Time.deltaTime;
            }
            if (disparar)
            {
                ani.SetBool("Disparar", true);
            }
            else
            {
                ani.SetBool("Disparar", false);
            }
        }
        else
        {
            StopAllCoroutines();
        }

        barra.fillAmount = tiempo / tiempoSpawn;
    }

    public void NoDisparar()
    {
        disparar = false;
    }
    IEnumerator MoverCañon(Vector3 a, Vector3 b, float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            float t = curva.Evaluate(i / time);
            cañon.position = Vector3.Lerp(a, b, t);
            yield return null;
        }
        cañon.position = b;
        enPosicion = true;
    }
    IEnumerator CañonSpawn()
    {
        current++;
        disparar = true;
        particula.Play();
        int aleatorioItems = Random.Range(0, items.Count);
        GameObject item = Instantiate(items[aleatorioItems], pivotSpawn.position + pivotSpawn.up, pivotSpawn.rotation);
        item.GetComponent<Rigidbody2D>().AddForce(pivotSpawn.up * velocidadDisparo, ForceMode2D.Impulse);

        yield return null;
    }
}
