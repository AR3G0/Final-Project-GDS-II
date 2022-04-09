using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vineWallGrowth : MonoBehaviour
{
    public float growth = 1f;

    public GameObject wall;
    public GameObject vine1;
    public GameObject vine2;
    public GameObject seaWeed1;
    public GameObject seaWeed2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "lightCone")
        {
            Debug.Log("Trigger");

            growth -= 0.0125f;
        }
    }
}
