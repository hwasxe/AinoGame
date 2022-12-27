using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KeyDoorController : MonoBehaviour
{
    private Animator animator;
    public Camera camera;
    private bool isDoorOpen = false;
    private bool keyTaken = false;
    private AudioSource audioSource;
    public AudioClip OpenDoorSound;
    public AudioClip CloseDoorSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        audioSource.Stop();
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
                            audioSource.PlayOneShot(OpenDoorSound,10);
                            animator.Play("door_open",0,0.0f);
                            StartCoroutine(CloseAfterTime(4));
                            
                        }
                    }
                    else
                    {
                        GameObject.Find("NotificationManager").GetComponent<NotificationManager>().SetNotification("You do not have the main door key!\nLook around the house....",5);
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
        audioSource.PlayOneShot(CloseDoorSound,10);
        animator.Play("door_close",0,0.0f);
        // Code to execute after the delay
        keyTaken = false;
    }

    
    
}
