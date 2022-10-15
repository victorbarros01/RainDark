using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life;
    Blinking[] blink;
    private DropItem drop;
    
    void Start()
    {
        blink = gameObject.GetComponentsInChildren<Blinking>();
        drop = GetComponent<DropItem>();
    }

    void Blink(){
        foreach(Blinking b in blink){
            b.Hit();
        }
    }

    void OnCollisionEnter(Collision other){

        if(other.gameObject.CompareTag("Player")){
            life -= 10000;
        }

        if (other.gameObject.CompareTag("Bolha")){
            life-= 10000;
        }

        if (other.gameObject.CompareTag("BulletPlayerPU")){
            Destroy(other.gameObject);
            life -= 8;
            Blink();

        }
        if (other.gameObject.CompareTag("BulletPlayer1")){
            Destroy(other.gameObject);
            life -= 2;
            Blink();
        }
        if (other.gameObject.CompareTag("BulletPlayer2")){
            Destroy(other.gameObject);
            life -= 4;
            Blink();
        }
        if (other.gameObject.CompareTag("BulletPlayer")){
            Destroy(other.gameObject);
            life-=1;
            Blink();
        }

        if(life <= 0){
            GetComponent<Explosion>().Play();
            Destroy(gameObject);
            drop.Drop();
        }
    }
    
}
