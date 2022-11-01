using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    bool blinking;
    Material material;
    Color color;
    public Color BlinkColor;
    [SerializeField] string ColorProperty = "_Color";
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        color = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (blinking){
            float t = Mathf.PingPong(Time.time * 5.0f, 1f);
            material.SetColor(ColorProperty, Color.Lerp(color, BlinkColor, t));
}
    }

    public void Hit(){
        blinking = true;
        Invoke("StopBlinking", 2.0f);
    }

    void StopBlinking(){
        blinking = false;
        material.color = color;
    }
}
