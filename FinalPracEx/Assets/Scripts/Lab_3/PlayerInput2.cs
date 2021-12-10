using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput2 : MonoBehaviour
{
    public Animator animator;
    bool facingRight = true;

    void flipSprite()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!facingRight)
            {
                flipSprite();
            }
            animator.SetBool("Run", true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (facingRight)
            {
                flipSprite();
            }
            animator.SetBool("Run", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Run", false);

        }

    }
}