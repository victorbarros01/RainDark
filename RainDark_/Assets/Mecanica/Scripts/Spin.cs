using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public Vector3 SpinSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.localRotation *= Quaternion.Euler(SpinSpeed * Time.deltaTime) ;
    }
}
