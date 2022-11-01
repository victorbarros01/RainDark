using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolha : MonoBehaviour
{
    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Enemy")){

        }
    }
}
