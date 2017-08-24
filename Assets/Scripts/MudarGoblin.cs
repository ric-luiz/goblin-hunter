using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarGoblin : MonoBehaviour {

    public GameObject[] goblins;
    int index = 0;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            avancarIndex();
        }
    }

    void avancarIndex()
    {
        index++;
        index = index % goblins.Length ;
    }

    public GameObject devolverGoblinEscolhido() {
        return goblins[index];
    }

}
