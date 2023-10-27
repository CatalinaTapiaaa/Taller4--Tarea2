using System.Collections;
using System.Collections.Generic;
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

    bool enPosicion, spawn, rotar, disparar;
    float t;
    int current, aleatorioRotacion;

    void Start()
    {
        particula.Stop();
    }

    void Update()
    {
        if (!desactivar)
        {
            if (activar)
            {
                int aleatorioMover = Random.Range(0, pivotsMover.Length);
                aleatorioRotacion = Random.Range(0, pivotsRotar.Length);

                StartCoroutine(MoverCañon(cañon.position, pivotsMover[aleatorioMover].position, velocidadMovimiento));
                rotar = true;
                activar = false;
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
                StartCoroutine(CañonSpawn());
                spawn = false;
            }          
            if (current >= cantidadSpawn)
            {
                StopAllCoroutines();
                current = 0;
                listo = true;
            }
            if (rotar)
            {
                Vector2 direccion = pivotsRotar[aleatorioRotacion].position - cañon.position;
                cañon.up = direccion * Time.deltaTime;
            }

            if (disparar)
            {
                ani.SetBool("Disparar", true);
                particula.Play();
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
    }

    public void NoDisparar()
    {
        disparar = false;
        particula.Stop();
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
        while (true)
        {
            current++;
            disparar = true;
            int aleatorioItems = Random.Range(0, items.Count);
            GameObject item = Instantiate(items[aleatorioItems], pivotSpawn.position + pivotSpawn.up, transform.rotation);
            item.GetComponent<Rigidbody2D>().AddForce(pivotSpawn.up * velocidadDisparo, ForceMode2D.Impulse);

            yield return new WaitForSeconds(tiempoSpawn);
        }
    }
}
