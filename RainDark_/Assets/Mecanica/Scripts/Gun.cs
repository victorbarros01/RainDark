using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{   
    [SerializeField] private KeyCode Btiro;
    [SerializeField] private GameObject tiro;
    [SerializeField] private AudioSource sound;
    [SerializeField] private float firerate;
    float Ultimotiro = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
         
        if(GameObject.FindObjectOfType<ScriptPause>().IsPaused)
        {
            return;
        }

        if(Input.GetButton("Fire1")&& Time.time > Ultimotiro ){
            Ultimotiro = Time.time + firerate;
            Instantiate(tiro, transform.position, transform.rotation);
            sound.Play();
            
        }
        
    }
}
