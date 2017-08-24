using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraGoblin : LifeBarController {

    protected override void Start()
    {
        recuperarAtributos();        
    }

    protected override void recuperarVida()
    {
        recuperarAtributos();
        this.VidaAtual = personagem.GetComponent<AcoesGoblin>().Vida;
    }

    protected override void recuperarAtributos() {
        if (personagem.GetComponent<AcoesGoblin>() != null && this.MaximoVida == -1) {
            this.MaximoVida = personagem.GetComponent<AcoesGoblin>().Vida;
        }

        if (personagem.GetComponent<AcoesGoblin>() != null && this.VidaAtual == -1) {
            this.VidaAtual = personagem.GetComponent<AcoesGoblin>().Vida;
        }
    }
    
}
