using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject pauseMenu;
    bool jogoPausado = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            mudarStatusMenuPause();
        }
    }

    public void mudarStatusMenuPause() {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        pausarGame();
    }

    void pausarGame() {

        //mudamos o jogo para pausado ou continue
        jogoPausado = !jogoPausado;

        if (jogoPausado)
        {
            Time.timeScale = 0.0f;            
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void selecaoContratos()
    {
        pausarGame();
        SceneManager.LoadScene(1);
    }

}
