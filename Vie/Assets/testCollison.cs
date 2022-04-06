using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCollison : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("It works over here???");
    }

    public void Update()
    {
        Debug.Log("Is this thing on?");
    }
}
