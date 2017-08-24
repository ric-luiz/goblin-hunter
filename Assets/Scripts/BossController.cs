using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour {

    NavMeshAgent agent;
    Animator animator;

    //variaveis referentes a movimentação entre os pontos
    GameObject pontos; //gameobject contendo a lista de pontos que o boss vai ficar andando
    Transform[] arrayPontos;
    int destPoint = 0;
    bool irParaNovaPosicao = true;
    float distanciaMaximaPonto = 0.5f;
    float tempoParaMovimentarEntrePosicoes = 15.0f;

    [Range(0,20.0f)]
    [SerializeField] float ditanciaMaximaGuerreiro = 15.0f;
    [Range(0, 10.0f)]
    [SerializeField] float ditanciaMinimaGuerreiro = 3.0f;
    GameObject guerreiro;
    bool encontrouGuerreiro = false;
    bool atacarGuerreiro = false;
    
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        guerreiro = GameObject.FindGameObjectWithTag("Player");
        preencherArrayPontos();
    }
		
	void Update () {

        if (podeMovimentarAleatoriamente())
            movimentarAleatoriamente();

        detectarGuerreiro();
        animacoes();
    }


    /*##################### Referente a movimentação entre os pontos #####################*/
    void movimentarAleatoriamente()
    {        
        if (arrayPontos.Length == 0)
            return;
        
        agent.destination = arrayPontos[destPoint].position;        
        destPoint = (destPoint + 1) % arrayPontos.Length;

        StartCoroutine(liberarParaIrNovaPosicao());
    }

    bool podeMovimentarAleatoriamente() {
        bool condicao = chegouDestinoPonto() && irParaNovaPosicao && !encontrouGuerreiro;        
        return condicao;
    }

    bool chegouDestinoPonto() {
        return !agent.pathPending && agent.remainingDistance < distanciaMaximaPonto;
    }

    IEnumerator liberarParaIrNovaPosicao() {
        irParaNovaPosicao = false;
        yield return new WaitForSeconds(tempoParaMovimentarEntrePosicoes);
        irParaNovaPosicao = true;
    }


    /*##################### Referente a Deteccao Guerreiro #####################*/
    void detectarGuerreiro() {
        float distancia = Vector3.Distance(guerreiro.transform.position, transform.position);

        if (distancia < ditanciaMaximaGuerreiro) {
            encontrouGuerreiro = true;
            agent.destination = guerreiro.transform.position;
        } else {
            encontrouGuerreiro = false;
        }
    }

    void iniciarAtacarGuerreiro(GameObject guerreiro) {
        if (guerreiro.name.Equals(this.guerreiro.name))
        {
            Debug.Log("Batendo no guerreiro");
            atacarGuerreiro = true;
            agent.ResetPath();
        }
    }

    void pararAtacarGuerreiro(GameObject guerreiro) {
        if (guerreiro.name.Equals(this.guerreiro.name))
        {
            Debug.Log("Deixando no guerreiro");
            atacarGuerreiro = false;
        }
    }

    

    /*##################### Referente a animações #####################*/
    void animacoes() {
        walkAnimacao();
        attackAnimacao();
    }

    void walkAnimacao() {
        if ((!chegouDestinoPonto() || encontrouGuerreiro) && !atacarGuerreiro)
            animator.SetBool("walk", true);
        else
            animator.SetBool("walk", false);
    }

    void attackAnimacao() {
        if (atacarGuerreiro) {
            animator.SetTrigger("attack");
        }
    }


    /*##################### Utilidades #####################*/
    void preencherArrayPontos()
    {
        pontos = transform.Find("pontos").gameObject;
        arrayPontos = new Transform[pontos.transform.childCount];

        for (int i = 0; i < pontos.transform.childCount; i++)
        { //preencher o array de pontos
            arrayPontos[i] = pontos.transform.GetChild(i);
        }

    }

    void OnTriggerStay(Collider other)
    {
        iniciarAtacarGuerreiro(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        pararAtacarGuerreiro(other.gameObject);
    }
}
