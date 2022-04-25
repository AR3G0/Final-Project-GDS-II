using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //get a refernce to the parent object
           var p = transform.parent;

            // make the new checkpoints position equal this transform.
           checkPointSystem newCheckPoint = p.GetComponent<checkPointSystem>();
           newCheckPoint.playerCheckPointLocation = collision.transform.position;

            //destroy this check point so it cannot be hit twice.
            Destroy(gameObject);
        }
    }
}
