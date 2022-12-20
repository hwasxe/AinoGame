using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterChase : MonoBehaviour
{
    public GameObject Player;
    private NavMeshAgent NavMonster;
    float CurrentTime;
    private Animator animator;

    private Vector3 randomVector;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        NavMonster = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < 10)
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
