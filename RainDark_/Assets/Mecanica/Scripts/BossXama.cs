using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossXama : MonoBehaviour
{
    public int life;
    Blinking[] blink;
    private DropItem drop;
    [SerializeField]
    private AudioSource sound;
    BossLife vida;

    void Start()
    {
        blink = gameObject.GetComponentsInParent<Blinking>();
        drop = GetComponent<DropItem>();
        vida = GameObject.FindObjectOfType<BossLife>(true);
        vida.gameObject.SetActive(true);
    }



    void Blink()
    {
        foreach (Blinking b in blink)
        {
            b.Hit();
        }
    }



    void OnTriggerEnter(Collider other)
    {

            if (other.gameObject.CompareTag("BulletPlayerPU"))
            {
                life -= 8;
                Blink();

            }
            if (other.gameObject.CompareTag("BulletPlayer1"))
            {
                Destroy(other.gameObject);
                life -= 2;
                Blink();
            }
            if (other.gameObject.CompareTag("BulletPlayer2"))
            {
                Destroy(other.gameObject);
                life -= 4;
                Blink();
            }
            if (other.gameObject.CompareTag("BulletPlayer"))
            {
                Destroy(other.gameObject);
                life -= 1;
                Blink();
            }

            if (life <= 0)
            {
                vida.LoseLife(1);
                Destroy(gameObject);
            }

            if(sound != null){
                sound.Play();
            }

    }
}

