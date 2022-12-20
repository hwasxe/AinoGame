using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        if(Input.GetKeyDown((KeyCode.W)) || Input.GetKeyDown((KeyCode.S)) || Input.GetKeyDown((KeyCode.A)) || Input.GetKeyDown((KeyCode.S)) || Input.GetKeyDown((KeyCode.D)))
        {
            animator.SetTrigger("walk");
        }
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) )
        {
            animator.SetTrigger("idle");
        }
    }
}
