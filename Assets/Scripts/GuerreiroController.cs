using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerreiroController : MonoBehaviour {

    public float speed = 5.0f;
    public GameObject cabelo;

    Animator animator;
    Animator cabeloAnimator;

    void Start () {
        animator = GetComponent<Animator>();
        cabeloAnimator = cabelo.GetComponent<Animator>();
    }
		
	void Update () {
        levandoDamage();
        atacar();
        movimentarGuerreiro();
    }

    bool atacar() {
        bool atacando = Input.GetKeyDown(KeyCode.L);

        if (atacando) {
            animacaoGuerreiroAtacando();
        }

        return atacando;
    }

    bool levandoDamage() {
        bool damage = Input.GetKeyDown(KeyCode.K);

        if (damage) {
            animarGuerreiroDamage();
        }

        return damage;
    }

    void movimentarGuerreiro(){

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            movimentarGuerreiro(speed / 1.5f, speed / 1.5f, 45);
        } else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            movimentarGuerreiro(speed / 1.5f, -speed / 1.5f, 315);
        } else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            movimentarGuerreiro(-speed / 1.5f, speed / 1.5f, 135);
        } else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            movimentarGuerreiro(-speed / 1.5f, -speed / 1.5f, 225);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            movimentarGuerreiro(speed,0,0);            
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movimentarGuerreiro(-speed, 0, 180);            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movimentarGuerreiro(0, speed, 90);            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movimentarGuerreiro(0, -speed, 270);            
        }
        else
        {
            animarGuerreiroCorrendo(false);
        }

    }

    void movimentarGuerreiro(float vertical, float horizontal,float rotacao) {
        
        transform.Translate(Vector3.right * horizontal * Time.deltaTime, Space.World); //movimentação direita esquerda
        transform.Translate(Vector3.forward * vertical * Time.deltaTime, Space.World); //movimentação cima baixo

        rotacionar(rotacao);
        animarGuerreiroCorrendo(true);
    }

    void rotacionar(float posicao) {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,posicao, transform.eulerAngles.z);        
    }

    void animarGuerreiroCorrendo(bool status) {
        animator.SetBool("run",status);
        cabeloAnimator.SetBool("run", status);
    }

    void animacaoGuerreiroAtacando() {
        animator.SetTrigger("attack");
        cabeloAnimator.SetTrigger("attack");
    }

    void animarGuerreiroDamage() {
        animator.SetTrigger("damage");
        cabeloAnimator.SetTrigger("damage");
    }
}
