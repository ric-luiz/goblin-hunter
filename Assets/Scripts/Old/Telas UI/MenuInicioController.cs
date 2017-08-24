using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicioController : MonoBehaviour {

    public Transform seletor;

    public void realizarDeslocamentoSelector() {
        seletor.position = transform.position;    
    }

    public void iniciarJogo() {        
        SceneManager.LoadScene(1);
    }

    public void sair() {
        Application.Quit();
    }

}
