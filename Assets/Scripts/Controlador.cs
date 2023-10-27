using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
	public int puntuacion;
	public int puntacionMax;
	static bool created;

	public void Start()
	{
		if (created)
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
		created = true;
	}

    void Update()
    {
        if (puntuacion > puntacionMax)
        {
			puntacionMax = puntuacion;
		}
    }

    void Load()
	{
		if (PlayerPrefs.HasKey("Puntuacion"))
		{
			puntuacion = PlayerPrefs.GetInt("Puntuacion");
		}
		if (PlayerPrefs.HasKey("PuntacionMax"))
		{
			puntacionMax = PlayerPrefs.GetInt("PuntacionMax");
		}
	}
}
