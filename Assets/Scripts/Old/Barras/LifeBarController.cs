using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarController : MonoBehaviour {

    public Transform barraVida;
    public GameObject personagem;

    float maximoVida = -1; //serve para sabermos sempre qual o total de vida. Usamos para pegar o proporcional de scale na barra 
    float vidaAtual = -1;

    virtual protected void Start() {        
    }

    void Update () {
        recuperarAtributos();
        if (maximoVida >= 0 && vidaAtual >= 0) {            
            this.barraVida.localScale = new Vector3(calcularScaleBarra(), this.barraVida.localScale.y, this.barraVida.localScale.z);
            recuperarVida();
        }
	}

    virtual protected void recuperarVida() {}

    virtual protected void recuperarAtributos() {}

    protected float calcularScaleBarra() {

        //essas condições evitam que a barra ultrapasse o limite ao fazer o scale
        if (vidaAtual < 0)
            vidaAtual = 0;

        if (vidaAtual > maximoVida)
            vidaAtual = maximoVida;

        return vidaAtual / maximoVida;

    }

    public float MaximoVida
    {
        get
        {
            return maximoVida;
        }

        set
        {
            maximoVida = value;
        }
    }

    public float VidaAtual
    {
        get
        {
            return vidaAtual;
        }

        set
        {
            vidaAtual = value;
        }
    }
}
