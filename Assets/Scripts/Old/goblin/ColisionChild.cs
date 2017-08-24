using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionChild : MonoBehaviour {

    //sempre que o filho detectar uma colisao passa para o pai
    // void OnTrigger(Collider other)
    // {
    //     if (other.tag.Equals("Player"))
    //         GetComponentInParent<AcoesGoblin>().colisionChild(other,gameObject);
    // }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
            GetComponentInParent<AcoesGoblin>().colisionChild(other,gameObject);
    }

}
