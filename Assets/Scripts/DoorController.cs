using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorController : MonoBehaviour
{
    private Animator animator;
    public Camera camera;
    private bool isDoorOpen = false;
    private bool keyTaken = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position,camera.transform.forward, out hit,2))
        {
            if (hit.transform.CompareTag("Door"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (keyTaken)
                    {
                        if (!isDoorOpen)
                        {
                            animator.Play("door_open",0,0.0f);
                            StartCoroutine(CloseAfterTime(4));
                        }
                    }
                    else
                    {
                        //Make sound and print that key is not taken !!!
                    }
                    
                }
            }
            
        }
    }

    public void SetKeyTakenTrue()
    {
        keyTaken = true;
    }
    IEnumerator CloseAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        animator.Play("door_close",0,0.0f);
        // Code to execute after the delay
    }

    
    
}
