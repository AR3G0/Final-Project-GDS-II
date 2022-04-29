using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    public Shaker shaker;
    public float duration = 1f;
    public float triggerRange;
    public float lifeSpan;

    private void Awake()
    {
        lifeSpan = lifeSpan * 60;
    }


    public GameObject player;

    void FixedUpdate()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 25f)
        {
            if (distance < triggerRange)
            {
                lifeSpan -= 1f;
                if (lifeSpan < 0) Destroy(gameObject);
            }
            shaker.shake(duration);
        }

    }
}
