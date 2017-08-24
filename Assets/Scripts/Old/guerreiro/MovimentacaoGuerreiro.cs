using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovimentacaoGuerreiro : MonoBehaviour {

    [Range(0.0f, 20.0f)]
    [SerializeField]
    float velocidade = 10.0f;

    private Vector3 moveDirectionX = Vector3.zero;
    private Vector3 moveDirectionZ = Vector3.zero;

    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        movimentacaoGuerreiro();
    }

    void movimentacaoGuerreiro()
    {       
        moverPosicaoX();
        moverPosicaoZ();
    }

    void moverPosicaoX() {
        moveDirectionX = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        moveDirectionX = transform.TransformDirection(moveDirectionX);
        moveDirectionX *= velocidade;

        controller.Move(moveDirectionX * Time.deltaTime);
        
    }

    void moverPosicaoZ() {

        moveDirectionZ = new Vector3(0, 0, Input.GetAxis("Vertical"));

        moveDirectionZ = transform.TransformDirection(moveDirectionZ);
        moveDirectionZ *= velocidade;

        controller.Move(moveDirectionZ * Time.deltaTime);        

    }

}
