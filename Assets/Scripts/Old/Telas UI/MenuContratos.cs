using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContratos : MonoBehaviour {

    public Transform seletor;

    public void realizarDeslocamentoSelector()
    {
        seletor.position = transform.position;
    }

    public void iniciarFloresta() {
        SceneManager.LoadScene(2);
    }

}
