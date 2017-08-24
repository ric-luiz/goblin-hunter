using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionChildGuerreiro : MonoBehaviour {

    //sempre que o filho detectar uma colisao passa para o pai
    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("inimigo"))
            GetComponentInParent<AcoesGuerreiro>().colisionChild(other, gameObject);
    }
}
