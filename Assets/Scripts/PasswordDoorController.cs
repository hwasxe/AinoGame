using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PasswordDoorController : MonoBehaviour
{
    private Animator animator;
    public Camera camera;
    private bool isDoorOpen = false;
    private AudioSource audioSource;
    private GameObject KeyPad;
    public AudioClip OpenDoorSound;

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
            if (hit.transform.CompareTag("PasswordDoor"))
            {
                
                Debug.Log("Touched Door with E");
                if (Input.GetKeyDown(KeyCode.E) && !isDoorOpen)
                {
                    GameObject.Find("Camera").GetComponent<MouseLook>().enabled = false;
                    Cursor.visible = true;
                    KeyPad = hit.transform.GetChild(0).gameObject;
                    KeyPad.SetActive(true);
                }
            }
        }
    }

    public void OpenDoor()
    {
        KeyPad.SetActive(false);
        audioSource.PlayOneShot(OpenDoorSound,10);
        animator.Play("door_open",0,0.0f);
        isDoorOpen = true;
    
    }
}
