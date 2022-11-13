using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public GameObject[] life;
    public int CurrentLife = 3;

    public void SetCurrentLife(int vida){
        for(int f = 0; f < life.Length; f++){
            life[f].SetActive(f < vida);
        }

        CurrentLife = vida;
    }

    public void LoseLife(int i){
        SetCurrentLife(CurrentLife - i);
    }


}
