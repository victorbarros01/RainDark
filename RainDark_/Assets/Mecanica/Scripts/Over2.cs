using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over2 : MonoBehaviour
{
    player Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {
        Player.Over = 2;
    }
}
