using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despertar : MonoBehaviour
{
 public float size = 20;
    public LayerMask layer;
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject e in objects){
                if(e != null){
                    e.SetActive(false);
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.CheckBox(transform.position, new Vector3(size, size, size), transform.rotation, layer)){
            foreach(GameObject e in objects){
                if(e != null){
                    e.SetActive(true);
                }
            }
        }
    }
}
