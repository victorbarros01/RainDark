using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{   
    [SerializeField]
    private GameObject ShieldI;
    public player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<player>();




    }

        void OnCollisionEnter(Collision player){

            if(player.gameObject.CompareTag("Player")){
                Debug.Log("Hello");
            }

        }


    // Update is called once per frame
    void Update()
    {
        
    }
}
