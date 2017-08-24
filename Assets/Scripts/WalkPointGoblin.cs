using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkPointGoblin : MonoBehaviour {
    NavMeshAgent agent;
    GameObject goblinEscolhido;
    Animator animator;
    public MudarGoblin GoblinController;

    void Start()
    {
        escolherGoblin();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            takeHit();
            animator.SetBool("walk", true);
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            animator.SetTrigger("attack");
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            animator.SetTrigger("damage");
        }

        escolherGoblin();
        animacaoGoblin();
    }

    void takeHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            agent.destination = hit.point;
        }
    }

    void animacaoGoblin() {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            animator.SetBool("walk", false);
        }
    }

    void escolherGoblin() {
        goblinEscolhido = GoblinController.devolverGoblinEscolhido();
        agent = goblinEscolhido.GetComponent<NavMeshAgent>();
        animator = goblinEscolhido.GetComponent<Animator>();
    }

}
