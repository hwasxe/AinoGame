using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareScript : MonoBehaviour
{
    private HealthCalculator healthCalculator;
    public GameObject sface;
    // Start is called before the first frame update
    void Start()
    {
        healthCalculator = GameObject.Find("HealthBar").GetComponent<HealthCalculator>();
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
            healthCalculator.getDamageNormal();
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
