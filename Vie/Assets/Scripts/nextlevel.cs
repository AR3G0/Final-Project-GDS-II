using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{

    public string levelToGoTo;

    // when the player collides with this box, trigger the next level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            checkPointSystem.playerCheckPointLocation = new Vector3(0f, 0f, 0f);

            SceneManager.LoadScene(levelToGoTo, LoadSceneMode.Single);
        }
    }
}
