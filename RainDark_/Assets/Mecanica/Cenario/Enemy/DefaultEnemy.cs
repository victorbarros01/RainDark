using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : MonoBehaviour
{
    public int life;
    Blinking[] blink;
    private DropItem drop;
    [SerializeField]
    private AudioSource sound;

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


    void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("BulletPlayerPU")){
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
            sound.Play();
            Destroy(gameObject);
            drop.Drop();
        }
    }
}
