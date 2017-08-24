using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class walkpointBoss : MonoBehaviour {

    NavMeshAgent agent;    
    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            takeHit();            
            animator.SetBool("walk", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("attack");
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            animator.SetTrigger("damage");
        }

        animatorBoss();
    }
     
    void takeHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            agent.destination = hit.point;
        }
    }

    void animatorBoss()
    {
        if (animator != null)
        {           
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                animator.SetBool("walk", false);                
            }

        }
    }

}
