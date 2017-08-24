using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraGuerreiro : LifeBarController {


    protected override void Start() {
        this.MaximoVida = personagem.GetComponent<AcoesGuerreiro>().Vida;
        this.VidaAtual = personagem.GetComponent<AcoesGuerreiro>().Vida;
    }

    protected override void recuperarVida()
    {
        this.VidaAtual = personagem.GetComponent<AcoesGuerreiro>().Vida;        
    }
}
