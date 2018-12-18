using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NeutralMovement : MonoBehaviour
{

    Transform elephant;
    NavMeshAgent nav;
    // Use this for initialization
    void Start()
    {
       
        
        nav = GetComponent<NavMeshAgent>();
        elephant = GameObject.FindGameObjectWithTag("Elephant").transform;
            
    }

    // Update is called once per frame
    void Update()
    {
        var x = Random.Range(0, 200);
        var z = Random.Range(0, 200);


        Vector3 vector0 = new Vector3();
        vector0 = elephant.position;
        Vector3 vector = new Vector3(200, vector0.y, 200);
        nav.SetDestination(vector);
    }
}