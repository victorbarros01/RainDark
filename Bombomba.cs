using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombomba : Enemy
{


    void OnCollisionEnter(Collision other){

        if(other.gameObject.CompareTag("Player")){
                life -= 1000;
            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
