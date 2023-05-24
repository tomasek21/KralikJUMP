using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Startgame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void GoHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Again()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    

    public void SwitchScena()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
