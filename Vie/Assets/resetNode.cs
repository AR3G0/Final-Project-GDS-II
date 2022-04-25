using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetNode : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //get a refernce to the parent object
            var p = transform.parent;

            // Move the player to the stored checkpoint position.
            checkPointSystem checkpointscript = p.GetComponent<checkPointSystem>();
            checkpointscript.resetToLastCheckPoint();
        }
    }
}
