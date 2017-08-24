using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AcoesGoblin : MonoBehaviour {

    [Range(0, 100)]
    [SerializeField]

    public int vidaMaxima = 30;
    public int vida = 30;    

    [Range(0, 100)]
    [SerializeField]
    int danoCausado = 2;

    [Range(0.0f, 5.0f)]
    [SerializeField]  float distanciaMinimaDoJogador = 2.0f;
    [SerializeField]  float raioDeVisão = 3.0f;

    [SerializeField] GameObject arma;
    Animator armaAnimator;
    bool atacando = false;

    public Transform jogador;    
    NavMeshAgent agent;

    [Range(0.0f, 5.0f)]
    [SerializeField]
    float TempoInfligirDano = 1.0f;
    bool PodeinfligirDano = true; //serve para fazermos os danos serem infligidos em intervalos de tempo    

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(jogador.position );
        armaAnimator = arma.GetComponent<Animator>();
    }
		
	void Update () {
        movimentarGoblin();

        if(vida<=0)
        {
         gameObject.SetActive(false);
        }
	}

    public void newPosition()
    {
        if(jogador!=null && agent!=null)
        {
        agent.SetDestination(new Vector3(Random.Range(-jogador.position.x,jogador.position.x*2),
                                         transform.position.y,
                                         Random.Range(-jogador.position.z,jogador.position.z*2)) );
        }
    }

    void movimentarGoblin() {        

     if(Vector3.Distance(transform.position, jogador.transform.position) < raioDeVisão)
     {  
         
        if (Vector3.Distance(transform.position, jogador.transform.position) < distanciaMinimaDoJogador)
        { //se chegar proximo do jogador, o goblin para e começar a atacar
            atacando = true;
            armaAnimator.SetBool("atacar",atacando);
        }
        else
        {
            agent.ResetPath();
            atacando = false;
            armaAnimator.SetBool("atacar", atacando);
        }


        agent.SetDestination(jogador.position);
     }
     

     
    }

    //informa se o guerreiro esta realizando um ataque
    public bool guerreiroIsAtacando()
    {
        return atacando;
    }

    //função para devolver o dano causado pelo guerreiro
    public int causarDano()
    {
        if (PodeinfligirDano) {
            PodeinfligirDano = false;
            StartCoroutine(habilitarPodeLevarDano());
            return danoCausado;            
        } else {
            return 0;
        }        
    }

    //Espera um tempo para permitir que o jogador receba novamente dano
    IEnumerator habilitarPodeLevarDano()
    {
        yield return new WaitForSeconds(TempoInfligirDano);
        PodeinfligirDano = true;
    }

    //recebe dano de um dos inimigos
    public void receberDano(int danoRecebido)
    {
        this.Vida -= danoRecebido;        
    }

    public void colisionChild(Collider other, GameObject filho)
    {
        if (other.tag.Equals("Player"))
            other.GetComponent<AcoesGuerreiro>().receberDano(causarDano());
    }

    public int Vida
    {
        get
        {
            return vida;
        }

        set
        {
            vida = value;
        }

    }
}
