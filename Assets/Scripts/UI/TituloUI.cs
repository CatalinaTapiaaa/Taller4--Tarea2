using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TituloUI : MonoBehaviour
{
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
    public void Creditos()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(5);
    }
    public void Titulo3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
}
