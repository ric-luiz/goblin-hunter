using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {

    public GameObject player;
	public GameObject boos;


	void Start () {
		

	}
	
	void Update () {


		if(player.GetComponent<AcoesGuerreiro>().Vida<=0)
        {
		 Debug.Log("Voce Morreu!");
		 // carega a tela de game over
		 //SceneManager.LoadScene("fim");
		}
       
	   if(boos.GetComponent<AcoesGoblin>().vida<=0)
	   {
		   Debug.Log("Voce cumpriu o CONTRATO!");
		   //vai para o menu de contratos
		   SceneManager.LoadScene("Contratos");
	   }
		
	}
}
