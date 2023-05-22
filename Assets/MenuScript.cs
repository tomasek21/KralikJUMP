using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    

    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void ShowTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
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
