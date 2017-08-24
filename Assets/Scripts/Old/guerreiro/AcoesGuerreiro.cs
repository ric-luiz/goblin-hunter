using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AcoesGuerreiro : MonoBehaviour {

    [Range(0,100)]
    [SerializeField] int vida = 100;

    [Range(0.0f, 20.0f)]
    [SerializeField] float velocidadeZ = 10.0f;

    [Range(0.0f, 20.0f)]
    [SerializeField]
    float velocidadeX = 5.0f;

    private Vector3 moveDirectionX = Vector3.zero;
    private Vector3 moveDirectionZ = Vector3.zero;

    CharacterController controller;

    [Range(0.0f, 180.0f)]
    [SerializeField] float velocidadeRotacao = 60.0f;

    [Range(0, 100)]
    [SerializeField] int danoCausado = 10;

    [SerializeField] GameObject arma;
    Animator armaAnimator;
    bool atacando = false; //informa que o guerreiro esta atacando   

    [Range(0.0f, 5.0f)]
    [SerializeField]
    float TempoInfligirDano = 1.0f;
    bool PodeinfligirDano = true; //serve para fazermos os danos serem infligidos em intervalos de tempo

    void Start () {
        armaAnimator = arma.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        
    }
		
	void Update () {
        movimentacaoGuerreiro();
        ataqueGuerreiro();
        olharParaMouse();        
    } 

    void movimentacaoGuerreiro()
    {
        moverPosicaoX();
        moverPosicaoZ();
    }

    void moverPosicaoX()
    {
        moveDirectionX = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        moveDirectionX = transform.TransformDirection(moveDirectionX);
        moveDirectionX *= velocidadeX;

        controller.Move(moveDirectionX * Time.deltaTime);

    }

    void moverPosicaoZ()
    {

        moveDirectionZ = new Vector3(0, 0, Input.GetAxis("Vertical"));

        moveDirectionZ = transform.TransformDirection(moveDirectionZ);
        moveDirectionZ *= velocidadeZ;

        controller.Move(moveDirectionZ * Time.deltaTime);

    }

    void olharParaMouse() {
        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, velocidadeRotacao * Time.deltaTime);
        }
    }

    void ataqueGuerreiro() {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            atacando = true;
            armaAnimator.SetBool("atacar", atacando);
        }
        else
        {
            atacando = false;
            armaAnimator.SetBool("atacar", atacando);
        }
    }

    //informa se o guerreiro esta realizando um ataque
    public bool guerreiroIsAtacando() {
        return atacando;
    }

    //função para devolver o dano causado pelo guerreiro
    public int causarDano() {
        if (PodeinfligirDano)
        {
            PodeinfligirDano = false;
            StartCoroutine(habilitarPodeLevarDano());
            return danoCausado;
        }
        else
        {
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
    public void receberDano(int danoRecebido) {
        this.Vida -= danoRecebido;
    } 

    public void colisionChild(Collider other, GameObject filho)
    {
        if (other.tag.Equals("inimigo") && guerreiroIsAtacando())
            other.GetComponent<AcoesGoblin>().receberDano(causarDano());
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
