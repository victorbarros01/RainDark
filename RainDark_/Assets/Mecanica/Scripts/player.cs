using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

    [SerializeField]
    private KeyCode kill;
    [SerializeField]
    private CharacterController Controller;
    [SerializeField]
    private float speed;
    public Transform DownRightLimit;
    public Transform UpLeftLimit;
    private bool AtvBolha;
    private int life = 6;
    private int count = 3;
    int GunLevel = 0;
    public float h;
    public GameObject[] vida;
    public float v;
    [SerializeField]
    private GameObject[] Guns;
    [SerializeField]
    private GameObject PowerUp;  // Especial
    [SerializeField]
    private GameObject Shield;   // Bolha de Proteção 1
    Blinking[] blink;           // Mecanica de piscar ao receber dano


    void Start() {
        //Atribuindo os componentes e componentes filhos da class Blinking para a variavel blink.
        blink = gameObject.GetComponentsInChildren<Blinking>();
        //Start está apenas desabilitando os objetos em cena,e
        AtualizarItem();
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

        h = Input.GetAxis("Horizontal");
       if((transform.position.x < UpLeftLimit.position.x)&& h < 0)h=0;

       if((transform.position.x > DownRightLimit.position.x)&& h > 0)h = 0;

        v = Input.GetAxis("Vertical");

       if((transform.position.y < DownRightLimit.position.y)&& v < 0)v = 0;
       if((transform.position.y > UpLeftLimit.position.y)&& v > 0)v = 0;


        Vector3 dir = new Vector3(h, v, 0);

        Controller.Move(dir * speed * Time.deltaTime);

        if (Input.GetKeyDown(kill)) {
            life = 0;

        }

        if(Input.GetButtonDown("PowerUp")&& count <= 0){
            count = 3;
            PowerUp.gameObject.SetActive(true);
            Invoke(nameof(DisablePU), 8f);  // Chama o metodo DisablePU depois de 8 segundos
        }
    }

        //desabilita objetos em cena
       void AtualizarItem(){
     //       gun1.gameObject.SetActive(false);
       //     gun2.gameObject.SetActive(false);
         //   gun3.gameObject.SetActive(false);
           for(int i = 0; i < Guns.Length; i++){
               Guns[i].SetActive(i == GunLevel);
           }
        }


        //Define parametros para colisão
        void OnTriggerEnter(Collider other){
            if (other.gameObject.CompareTag("Enemy")&& AtvBolha == false){
                life--;
                Destroy(vida[5].gameObject);
            if (vida[5].gameObject == null) Destroy(vida[4].gameObject);
            if (vida[4].gameObject == null) Destroy(vida[3].gameObject);
            if (vida[3].gameObject == null) Destroy(vida[2].gameObject);
            if (vida[2].gameObject == null) Destroy(vida[1].gameObject);
            if (vida[1].gameObject == null) Destroy(vida[0].gameObject);
            Blink();
                
            }

            if (other.gameObject.CompareTag("BulletEnemy")&& AtvBolha == false){
                life-= 4;
            Destroy(vida[5].gameObject);
            Destroy(vida[4].gameObject);
            Destroy(vida[3].gameObject);
            Destroy(vida[2].gameObject);
            if (vida[2].gameObject == null) Destroy(vida[1].gameObject);
            if (vida[1].gameObject == null) Destroy(vida[0].gameObject);
            Blink();
                
            }

            if (other.gameObject.CompareTag("Raio")){

                life-= 3;
            Destroy(vida[5].gameObject);
            Destroy(vida[4].gameObject);
            Destroy(vida[3].gameObject);
            if (vida[3].gameObject == null) Destroy(vida[1].gameObject);
            if (vida[2].gameObject == null) Destroy(vida[1].gameObject);
            if (vida[1].gameObject == null) Destroy(vida[0].gameObject);
            Blink();
                

            }

            if (life <= 0) {
                SceneManager.LoadScene("Game Over");

            }
            if (other.gameObject.CompareTag("Item")) {
                Item item = other.gameObject.GetComponent<Item>();


                switch (item.type) {

                    case Item.TYPES.ARMA1:
                        GunLevel= Mathf.Min(GunLevel+1, Guns.Length-1); // Permite colocar apenas a arma de ultimo nivel atribuida
                        AtualizarItem();
                        //gun2.gameObject.SetActive(true);
                        Destroy(other.gameObject);
                        break;

                    case Item.TYPES.POWERUP:
                            count--;

                            Destroy(other.gameObject);
                            //Debug.Log("Nao");
                            if (count <= 0)count = 0;

                        break;

                    case Item.TYPES.LIFE:
                        if (life < 6)life += 1;
                        Destroy(other.gameObject);
                        GameController.instance.Life();
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