using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public int life;
    Blinking[] blink;
    private DropItem drop;
    public GameObject boss;
    public GameObject[] Guns;
    [SerializeField]
    private AudioSource sound;
    BossLife vida;

    void Awake() {
        DisableGuns();
    }

    void DisableGuns(){
        for (int i = 0; i < Guns.Length; i++){
        Guns[i].SetActive(false);
        }
    }

    void Start()
    {
        blink = gameObject.GetComponentsInChildren<Blinking>();
        drop = GetComponent<DropItem>();
        vida = GameObject.FindObjectOfType<BossLife>(true);
        vida.gameObject.SetActive(true);
    }

    void Update(){
        if(boss == null)AtvGuns();
    }

    void Blink(){
        foreach(Blinking b in blink){
            b.Hit();
        }
    }

    void AtvGuns(){
        for (int i = 0; i < Guns.Length; i++){
            Guns[i].SetActive(true);
        }
    }


    void OnTriggerEnter(Collider other){
        if(boss == null) {
            if (other.gameObject.CompareTag("BulletPlayerPU")) {
                life -= 8;
                Blink();

            }
            if (other.gameObject.CompareTag("BulletPlayer1")) {
                Destroy(other.gameObject);
                life -= 2;
                Blink();
            }
            if (other.gameObject.CompareTag("BulletPlayer2")) {
                Destroy(other.gameObject);
                life -= 4;
                Blink();
            }
            if (other.gameObject.CompareTag("BulletPlayer")) {
                Destroy(other.gameObject);
                life -= 1;
                Blink();
            }

            if (life <= 0) {
                vida.LoseLife(1);
                GetComponent<Explosion>().Play();
                sound.Play();
                Destroy(gameObject);
            }
        }
    }
}
