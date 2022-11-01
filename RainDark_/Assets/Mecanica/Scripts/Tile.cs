using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour


{
    // Start is called before the first frame update
    void Start()
    {
        GerenciadorTile.Instance.TilesAtuais++;
        
    }

    void OnDestroy(){

        GerenciadorTile.Instance.TilesAtuais--;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
