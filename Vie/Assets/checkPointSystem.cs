using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointSystem : MonoBehaviour
{
    //store the players check point location
    public static Vector3 playerCheckPointLocation;

    //get a refernce to the player
    public GameObject player;
    public GameObject cam;



    // the first checkpoint location is the player's starting location
    private void Awake()
    {

        if (playerCheckPointLocation.x == 0)
            playerCheckPointLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

    }


    public void resetToLastCheckPoint()
    {
        player.transform.position = playerCheckPointLocation;
        cam.transform.position= playerCheckPointLocation;
    }

    private void Update()
    {
        Debug.Log(playerCheckPointLocation);
    }
}
