using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_linear : MonoBehaviour
{
    [SerializeField]private Vector3 dir; 
    [SerializeField]private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.deltaTime;
        transform.position += dir * speed * t;
    }
}
