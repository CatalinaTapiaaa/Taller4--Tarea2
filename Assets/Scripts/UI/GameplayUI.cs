using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
    public GameObject panelPausa;

    public void Pausar()
    {
        Time.timeScale = 0;
        panelPausa.SetActive(true);
    }
    public void VolverGame()
    {
        Time.timeScale = 1;
        panelPausa.SetActive(false);
    }
    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(4);
    }
    public void Titulo1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Titulo2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
