using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetController : MonoBehaviour
{
    public new Camera camera;

    private bool isDoorOpen = false;

    private Animator animator;
    private AudioSource audioSource;
    public AudioClip CabinetOpenDoorSound;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position,camera.transform.forward, out hit,2))
        {
            if (hit.transform.CompareTag("Cabinet"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("CABINET PRESSED");
                    
                        if (!isDoorOpen)
                        {
                            audioSource.PlayOneShot(CabinetOpenDoorSound,10);
                            animator.Play("cabinet_door_open");
                            isDoorOpen = false;
                        }

                }
            }
            
        }
    }
    
}
