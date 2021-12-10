using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    public ParticleSystem ps;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ps.Play();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ps.Stop();
        }
    }
}
