using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
        void OnTriggerEnter(Collider other){

            if(other.gameObject.CompareTag("Raio"))Destroy(other.gameObject);

        }

}
