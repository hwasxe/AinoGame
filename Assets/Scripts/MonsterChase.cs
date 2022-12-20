using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterChase : MonoBehaviour
{
    public GameObject Player;
    private NavMeshAgent NavMonster;
    
    // Start is called before the first frame update
    void Start()
    {
        NavMonster = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NavMonster.SetDestination(Player.transform.position);

    }
}
