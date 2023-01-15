using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterChase : MonoBehaviour
{
    public GameObject Player;
    private NavMeshAgent NavMonster;
    float CurrentTime;
    float damageCoolDownTimer;
    private Animator animator;
    public int chasingDistance = 5;
    private Vector3 randomVector;
    private GameObject healthForeGroundBar;
    private bool isAttacking = false;
    private HealthCalculator healthCalculator;
    // Start is called before the first frame update
    void Start()
    {
        
        healthCalculator = GameObject.Find("HealthBar").GetComponent<HealthCalculator>();
        animator = GetComponent<Animator>();
        NavMonster = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        damageCoolDownTimer += Time.deltaTime;
        
        if (!isAttacking)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <  chasingDistance)
            {
                animator.SetTrigger("move");
                NavMonster.SetDestination(Player.transform.position);
                
            }
            else
            {
            
                CurrentTime += Time.deltaTime;
                if(CurrentTime > 4){
                    animator.SetTrigger("walk");
                    randomVector = new Vector3(UnityEngine.Random.Range(-10, 10), 0, UnityEngine.Random.Range(-10, 10));
                    NavMonster.SetDestination(randomVector);
                    CurrentTime = 0;
                }
            
            
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            if (damageCoolDownTimer > 2)
            {
                healthCalculator.getDamageStrong();
                damageCoolDownTimer = 0;
            }
            CurrentTime = 0;
            isAttacking = true;
            animator.SetTrigger("attack");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        isAttacking = false;
        CurrentTime = 4;
        animator.SetTrigger("walk");
    }
}
