using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimySpawn : MonoBehaviour {

    public Transform jogador;
	public int numeraoMaximoDeInimigos = 10; 
    public float frequenciaDeSpawn = 2;
	private float spTime = 0;

    public Transform destino;
	public GameObject[] tiposDeInimigos;
	private GameObject[] inimigos;

	void Start () {
		inimigos = new GameObject[numeraoMaximoDeInimigos];
 
        jogador = GameObject.FindGameObjectWithTag("Player").transform;

        if(inimigos.Length>0)
		{
		for(int i =0;i<numeraoMaximoDeInimigos;i++)
		{
         GameObject inim = Instantiate(tiposDeInimigos[Random.Range(0,tiposDeInimigos.Length)], destino.position, Quaternion.identity);
		 inim.GetComponent<AcoesGoblin>().jogador = jogador;
         inim.SetActive(false);

         inimigos[i] = inim;
		}
		}else
		{
			Debug.LogError("Núnmero de inimigos não definido corretamente!");
		}
	}
	
	
	void Update () {


       if(spTime>frequenciaDeSpawn)
	   {
        foreach(var inim in inimigos)
		{
           if(inim.activeSelf == false)
		   {
			   inim.GetComponent<AcoesGoblin>().vida = inim.GetComponent<AcoesGoblin>().vidaMaxima;
			   inim.GetComponent<AcoesGoblin>().transform.position = destino.position;
			   inim.GetComponent<AcoesGoblin>().newPosition();
			   inim.SetActive(true);
			   break;
		   }
		}
		spTime = 0;
	   }

	   if(spTime<frequenciaDeSpawn)
	   {
		   spTime +=Time.deltaTime;
	   }
	}
}
