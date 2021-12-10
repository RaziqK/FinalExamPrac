using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeModel : MonoBehaviour
{
    private GameObject rHand;
    private bool isAnimating = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            isAnimating = !isAnimating;
        }
        Animator anim = GetComponent<Animator>();
        if (isAnimating)
        {
            anim.enabled = true;
            //Looping and no looping
            if (Input.GetKeyDown("l"))
            {
                anim.Play("Dude Walk", -1, 0.0f);
            }
            if (Input.GetKeyDown("k"))
            {
                anim.Play("Dude Walk No Loop", -1, 0.0f);
            }
        }
        else
        {
            anim.enabled = false;
            anim.StopPlayback();
        }

        //Rotates left arm
        if (!isAnimating)
        {
            GameObject leftArm = GameObject.Find(
            "Root/Pelvis/Spine/Spine1/Spine2/Spine3/Neck/L_Clavicle/L_UpperArm");
            if (Input.GetKeyDown("r"))
            {
                leftArm.transform.Rotate(0.0f, 0.0f, 90.0f);
            }
        }
        
        //Change speed property of the Animator object
        if (isAnimating)
        {
            if (Input.GetKeyDown("="))
            {
                anim.speed++;
            }
            if (Input.GetKeyDown("-") && anim.speed > 0)
            {
                anim.speed--;
            }
        }
    }
}
