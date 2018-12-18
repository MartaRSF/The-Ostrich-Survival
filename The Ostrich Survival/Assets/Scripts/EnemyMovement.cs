using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    Transform player;
    NavMeshAgent nav;
    // Use this for initialization
    void Start()
    {
        //MUDAR PARA PLAYER
        player = GameObject.FindGameObjectWithTag("Zebra").transform;
        nav = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        nav.SetDestination(player.position);
    }
}
