using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightPickUp : MonoBehaviour
{
    public AudioClip clip;
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();

        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (ps.isPlaying == false)
        {
            Destroy(gameObject);
        }*/
    }
}
