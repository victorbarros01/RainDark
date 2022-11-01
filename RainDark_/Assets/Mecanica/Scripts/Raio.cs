using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raio : MonoBehaviour
{

        private bool atvraio = false;
    [SerializeField]
        private GameObject tiro;




    void Start()
    {
        tiro.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {



        if(atvraio == true&& tiro != null){

            tiro.gameObject.SetActive(true);

        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Player"){
            atvraio = true;

        }
    }


}

