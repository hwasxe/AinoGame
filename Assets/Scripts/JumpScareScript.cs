using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareScript : MonoBehaviour
{

    public GameObject sface;
    // Start is called before the first frame update
    void Start()
    {
        sface.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sface.SetActive(true);
            StartCoroutine(TimerStart());
        }
    }

    IEnumerator TimerStart()
    {
        yield return new WaitForSeconds(1);
        sface.SetActive(false);
        Destroy((gameObject));
    }
}
