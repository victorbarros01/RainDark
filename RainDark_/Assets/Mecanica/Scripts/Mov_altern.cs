using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_altern : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedX;
    public float speedY;
    public float amplitudeX;
    public float amplitudeY;

    void Update()
    {
        float x = Mathf.Sin(transform.position.y) * amplitudeX;
        float y = Mathf.Sin(transform.position.x) * amplitudeY;
        Vector3 dir = new Vector3(x + speedX, y +speedY, 0);
        transform.position += dir * Time.deltaTime;
    }
}
