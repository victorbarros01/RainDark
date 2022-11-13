using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{   public GameObject tiro;
    public bool enableOnPlay = false;
    public float delay;
    public AudioSource sound;
    public Transform PaiDasBalas;

    // Start is called before the first frame update
        void Start()
        {
            if (enableOnPlay){
                StartSpawner(delay);
            }

        }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Bolha")){
            Destroy(gameObject);
        }
    }

        public void StartSpawner(float s){
            InvokeRepeating("Spawn", 0, s);
        }

        void Spawn(){
            if(PaiDasBalas != null) {
                Instantiate(tiro, transform.position, transform.rotation, PaiDasBalas);
            }else {
                Instantiate(tiro, transform.position, transform.rotation);
            }
            if (sound != null)sound.Play();

        }
}