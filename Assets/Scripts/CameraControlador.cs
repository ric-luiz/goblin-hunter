using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlador : MonoBehaviour {

    [SerializeField] GameObject jogador;

    Vector3 offset;

    private void Start()
    {
        offset = transform.position - jogador.transform.position;
    }

    void Update()
    {
        movimentarCameraToJogador();
    }

    void movimentarCameraToJogador()
    {
        if (jogador != null)
        {
            transform.position = jogador.transform.position + offset;
        }
        else
        {
            Debug.LogError("Variavel Jogador está Nula. Por favor preencha com o objeto correto no editor");
        }
    }
}
