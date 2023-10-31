using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derrota : MonoBehaviour
{
    public GameObject panelGameOver;
    public Animator aniGameOver;
    [Space]
    public float temblorDuracion;
    public float esperarMenu;
    public bool derrota;

    float temblorCantidad = 0.2f;
    float t;
    bool temblor, menu;

    void Update()
    {       
        if (derrota)
        {
            Temblando();

            GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
            GameObject[] malos = GameObject.FindGameObjectsWithTag("Malo");
            GameObject[] buenos = GameObject.FindGameObjectsWithTag("Bueno");
            foreach (var item in items)
            {
                Rigidbody2D itemRigidbody2D = item.GetComponent<Rigidbody2D>();

                if (itemRigidbody2D != null)
                {
                    itemRigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
                }
            }
            foreach (var malo in malos)
            {
                Rigidbody2D itemRigidbody2D = malo.GetComponent<Rigidbody2D>();

                if (itemRigidbody2D != null)
                {
                    itemRigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
                }
            }
            foreach (var bueno in buenos)
            {
                Rigidbody2D itemRigidbody2D = bueno.GetComponent<Rigidbody2D>();

                if (itemRigidbody2D != null)
                {
                    itemRigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
                }
            }
        }
        if (menu)
        {          
            t += Time.deltaTime;
            if (t >= esperarMenu)
            {
                panelGameOver.SetActive(true);
                aniGameOver.SetBool("Activar", true);
                menu = false;
            }
        }
    }

    IEnumerator Tembror()
    {
        if (temblor)
        {
            yield return null;
        }

        temblor = true;
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0;

        while (elapsed < temblorDuracion)
        {
            float x = Random.Range(-1f, 1f) * temblorCantidad;
            float y = Random.Range(-1f, 1f) * temblorCantidad;
            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
        menu = true;
        derrota = false;
        temblor = false;
    }
    void Temblando()
    {
        StartCoroutine(Tembror());
    }     
}
