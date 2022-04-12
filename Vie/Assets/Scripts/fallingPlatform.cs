using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    public Shaker shaker;
    public float duration = 1f;
    public float triggerRange = 25f;
    public float lifeSpan = 7.5f;

    private void Awake()
    {
        lifeSpan = lifeSpan * 60;
    }


    public GameObject player;

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < triggerRange)
        {
            if (distance < 2)
            {
                lifeSpan -= 1f;
                if (lifeSpan < 0) Destroy(gameObject);
            }
            shaker.shake(duration);
        }

    }
}
