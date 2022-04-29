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
    public void Feedback()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSd0z7dp7VvlUY16ki-O9nSUdw8KMLdU7ctC5ixbLfzctU6hvQ/viewform?entry.1508688123=Vie+-+Noah,+Gabe,+Madison,+Nico,+Laramie");
    }
}
