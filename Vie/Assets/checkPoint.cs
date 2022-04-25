using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // make the new checkpoints position equal this transform.
           checkPointSystem.playerCheckPointLocation = collision.transform.position;

            //destroy this check point so it cannot be hit twice.
            Destroy(gameObject);
        }
    }
}
