using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Desert - Lv.1");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void Level2()
    {
        SceneManager.LoadScene("Forest");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Climb - Lv 3");
    }
}
