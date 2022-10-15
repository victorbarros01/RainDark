using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPU : MonoBehaviour
{   public Material mat;
    public Color c1;
    public Color c2;
    // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            float v = Mathf.PingPong(Time.time, 0.5f); 
            //mat.color = c1 + c2; 
            mat.color = Color.Lerp(c1, c2, v);
        }
}