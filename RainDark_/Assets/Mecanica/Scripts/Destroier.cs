using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroier : MonoBehaviour
{
    public GameObject[] Objeto;

    void Update() {
        if(Objeto[0] == null){
            Destroy(Objeto[1].gameObject);
        }
    }
}
