using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{   
    [SerializeField] private GameObject tiro;
    [SerializeField] private AudioSource sound;
    [SerializeField] private float firerate;
    //private float Ultimotiro = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   


        if(Input.GetButton("PowerUp")){
            Instantiate(tiro, transform.position, transform.rotation);
            sound.Play();
            
        }
        
    }
}
