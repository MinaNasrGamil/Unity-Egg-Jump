using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// hna bygeb al next scene ally fe al queu
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit!");
    }
}
