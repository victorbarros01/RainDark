using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    [SerializeField]
    private KeyCode kill;
    [SerializeField]
    private float speed;
    //[SerializeField]const float limitX = 2.12f;
    //[SerializeField]const float limitYn = 0.58f;
    //[SerializeField]const float limitYp = 0.43f;
    [SerializeField]
    //private Transform target;
    private bool AtvBolha;
    private int life = 6;
    private int count = 3;
    [SerializeField]
    private GameObject gun1;     // Arma principal
    [SerializeField]
    private GameObject gun2;     // Segunda Arma
    [SerializeField]
    private GameObject gun3;     // Terceira Arma
    [SerializeField]
    private GameObject PowerUp;  // Especial
    [SerializeField]
    private GameObject Shield;   // Bolha de Proteção 1
    Blinking[] blink;           // Mecanica de piscar ao receber dano


    void Start() {
        //Atribuindo os componentes e componentes filhos da class Blinking para a variavel blink.
        blink = gameObject.GetComponentsInChildren<Blinking>();
        //Start está apenas desabilitando os objetos em cena,e
        gun2.gameObject.SetActive(false);
        gun3.gameObject.SetActive(false);
        PowerUp.gameObject.SetActive(false);
        Shield.gameObject.SetActive(false);
        //definindo o bool AtvBolha como falso
        AtvBolha = false;
    }


    void Blink() {
        //define para cara objeto com o script se tomar um hit vai retornar Blinking
        foreach (Blinking b in blink) {
            b.Hit();
        }
    }
//desabilita objeto em cena
    void DisablePU() {

    PowerUp.gameObject.SetActive(false);

    }



    void DisableShield() {
        //definindo o bool AtvBolha como falso
        AtvBolha = false;
        //desabilita objeto em cena
        Shield.gameObject.SetActive(false);

    }

    //Movimentação player
    void Update() {
        float t = Time.deltaTime;
        float h = Input.GetAxis("Horizontal");
        /*if (transform.position.x < (target.position.x - limitX)){
                h = 0.5f;
                
            }

            if(transform.position.x > (target.position.x + 0.5f)) h = 0;*/

        float v = Input.GetAxis("Vertical");
        /*if((transform.position.y < -limitYn)&& v < 0)v = 0;
                if((transform.position.y > limitYp)&& v > 0)v = 0;*/


        Vector3 dir = new Vector3(h, v, 0);

        transform.position += dir * speed * t;

        if (Input.GetKeyDown(kill)) {
            life = 0;

        }
    }

        //desabilita objetos em cena
        void InativarItem(){
            gun1.gameObject.SetActive(false);
            gun2.gameObject.SetActive(false);
            gun3.gameObject.SetActive(false);
        }

        //Define parametros para colisão
        void OnCollisionEnter(Collision other){
            if (other.gameObject.CompareTag("Enemy")&& AtvBolha == false){
                life--;
                Blink();
            }
            if (life <= 0) {
                Destroy(gameObject);

            }
            if (other.gameObject.CompareTag("Item")) {
                Item item = other.gameObject.GetComponent<Item>();


                switch (item.type) {

                    case Item.TYPES.ARMA1:
                        InativarItem();
                        gun2.gameObject.SetActive(true);
                        Destroy(other.gameObject);
                        break;

                    case Item.TYPES.ARMA2:
                        InativarItem();
                        gun3.gameObject.SetActive(true);
                        Destroy(other.gameObject);
                        break;

                    case Item.TYPES.POWERUP:
                            count--;

                            Destroy(other.gameObject);
                            //Debug.Log("Nao");
                            if (count == 0) {
                                Invoke(nameof(DisablePU), 8f);  // Chama o metodo DisablePU depois de 8 segundos
                                PowerUp.gameObject.SetActive(true);
                                //Debug.Log("Ola");
                                count = 3;
                                }
                        break;

                    case Item.TYPES.LIFE:
                        if (life < 6)life += 1;
                        Destroy(other.gameObject);
                        break;

                    case Item.TYPES.SHIELD:
                        Invoke(nameof(DisableShield), 5f); //Chama o metodo DisableShield depois de 5 segundos
                        AtvBolha = true;
                        Shield.gameObject.SetActive(true);
                        Destroy(other.gameObject);
                        break;


                }


            }
        }
    }