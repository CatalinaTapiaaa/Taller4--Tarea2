using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
    public void Pausar()
    {
        Time.timeScale = 0;
    }
    public void VolverGame()
    {
        Time.timeScale = 1;
    }  
    public void Titulo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
