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
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        GameObject[] buenos = GameObject.FindGameObjectsWithTag("Bueno");
        GameObject[] malos = GameObject.FindGameObjectsWithTag("Malo");

        if (derrota)
        {
            Temblando();
            Time.timeScale = Mathf.Lerp(1, 0.2f, 3);
        }
        if (menu)
        {
            t += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(0.2f, 1, 3);

            foreach (GameObject item in items)
            {
                Rigidbody2D itemRigidbody2D = item.GetComponent<Rigidbody2D>();

                if (itemRigidbody2D != null)
                {
                    itemRigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                }
            }
            foreach (GameObject bueno in buenos)
            {
                Rigidbody2D itemRigidbody2D = bueno.GetComponent<Rigidbody2D>();

                if (itemRigidbody2D != null)
                {
                    itemRigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                }
            }
            foreach (GameObject malo in malos)
            {
                Rigidbody2D itemRigidbody2D = malo.GetComponent<Rigidbody2D>();

                if (itemRigidbody2D != null)
                {
                    itemRigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                }
            }

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
