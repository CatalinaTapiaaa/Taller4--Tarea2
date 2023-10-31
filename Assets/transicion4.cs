using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transicion4 : MonoBehaviour
{
    public GameObject cometa;

    public void Final()
    {
        cometa.SetActive(true);
        Destroy(gameObject);
    }
}
