using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flyToBar : MonoBehaviour
{
    public float speed;
    public GameObject target;

    private ParticleSystem partSytem;
    private ParticleSystem.Particle[] parts;
            //int GetParticles(out Particle[] particles);

    private void Awake()
    {
        partSytem = GetComponent<ParticleSystem>();
    }


    private void LateUpdate()
    {
        //store all of the alive particles in an array
        int numParticlesAlive = partSytem.GetParticles(parts);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            //do something to the particle
            parts[i].position = Vector3.MoveTowards(parts[i].position, target.transform.position, speed * Time.deltaTime);
        }

        // Apply the particle changes to the Particle System
        partSytem.SetParticles(parts, numParticlesAlive);

    }

    /*

    private void FixedUpdate()
    {
        parts.Particle.position = Vector3.MoveTowards(parts.Particle.position, target.transform.position);
    }

    */
}
