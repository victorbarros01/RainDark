using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int life;
    public Text  txtLife;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

   public void Dano(){
        life--;
        txtLife.text = "Life: " + life;
    }

    public void DanoUp(){
        life-= 3;
        txtLife.text = "Life: " + life;
    }

    public void HitKill(){
        life-=6;
        txtLife.text = "Life: " + life;
    }

    public void Life(){
        if(life < 6) {
            life += 1;
            txtLife.text = "Life: " + life;
        }
    }

}
