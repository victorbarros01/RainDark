using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorTile : MonoBehaviour
{
    public GameObject[] VariarTiles;
    public GameObject BossTile;
    internal int TilesAtuais = 0;
    int TilesInstanciados;
    public int MaxTilesAtuais;
    public int TilesPreBoss;
    public Transform UltimoTile;
    public Vector3 EspacamentoTiles;
    public GameObject Boss;
    bool atvBoss = false;
    bool SpawnarTiles = true;
    public static GerenciadorTile Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != null)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Boss.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        if (!SpawnarTiles)
        {
            return;
        }

        if(TilesAtuais < MaxTilesAtuais)
        {
            TilesInstanciados++;

            if(TilesInstanciados < TilesPreBoss)
            {
                UltimoTile = Instantiate(VariarTiles[Random.Range(0, VariarTiles.Length)], UltimoTile.position + EspacamentoTiles, UltimoTile.rotation).transform;
            }
            else
            {
                UltimoTile = Instantiate(BossTile, UltimoTile.position + EspacamentoTiles, UltimoTile.rotation).transform;
                if(!atvBoss){
                    Invoke(nameof(EnableBossaNova), 3.0f);
                }
            }
        }
    }

    void EnableBossaNova(){
        Boss.SetActive(true);
        atvBoss = true;
    }
}
