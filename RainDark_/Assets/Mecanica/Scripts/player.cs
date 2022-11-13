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
    public int life = 6;
    private int count = 3;
    int GunLevel = 0;
    public float h;
    public float v;
    float z;
    public GameObject[] heartHUD = new GameObject[6];
    public GameObject[] PowerUpHUD = new GameObject[3];
    public bool ResetHudPU = false;
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
        z = transform.position.z;
        PowerUpHUD[0].SetActive(false);
        PowerUpHUD[1].SetActive(false);
        PowerUpHUD[2].SetActive(false);


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

        transform.position = new Vector3(transform.position.x, transform.position.y, z);

        if (Input.GetKey("f3")) {
            count = 0;

        }

        if(Input.GetButtonDown("PowerUp")&& count <= 0){
            count = 3;
            PowerUp.gameObject.SetActive(true);
            ResetHudPU = true;

            PU();
            Invoke(nameof(DisablePU), 8f);  // Chama o metodo DisablePU depois de 8 segundos
        }

        if(Input.GetKey("f1")) life = 1000 * 1000;
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

    void LifeMenosHUD(){

    switch(life)
    {

        case 5:
            heartHUD[5].SetActive(false);
            break;

        case 4:
            heartHUD[5].SetActive(false);
            heartHUD[4].SetActive(false);
            break;

        case 3:
            heartHUD[5].SetActive(false);
            heartHUD[4].SetActive(false);
            heartHUD[3].SetActive(false);
            break;

        case 2:
            heartHUD[5].SetActive(false);
            heartHUD[4].SetActive(false);
            heartHUD[3].SetActive(false);
            heartHUD[2].SetActive(false);
            break;

        case 1:
            heartHUD[5].SetActive(false);
            heartHUD[4].SetActive(false);
            heartHUD[3].SetActive(false);
            heartHUD[2].SetActive(false);
            heartHUD[1].SetActive(false);
            break;
    }
}

    void LifeMaisHUD(){

        switch(life)
        {
            case 6:
                heartHUD[5].SetActive(true);
                break;

            case 5:
                heartHUD[4].SetActive(true);
                break;

            case 4:
                heartHUD[3].SetActive(true);
                break;

            case 3:
                heartHUD[2].SetActive(true);
                break;

            case 2:
                heartHUD[1].SetActive(true);
                break;

            case 1:
                heartHUD[0].SetActive(true);
                break;
        }
    }

    void MenosLife() {

        if(life>0){
            LifeMenosHUD();
        }
    }

    void MaisLife() {
            LifeMaisHUD();

    }

    void DisableHUDPU(){
        PowerUpHUD[0].SetActive(false);
        PowerUpHUD[1].SetActive(false);
        PowerUpHUD[2].SetActive(false);
    }

    void HUDpowerUp(){
        switch (count){
            case 2:
                PowerUpHUD[0].SetActive(true);
                break;

            case 1:
                PowerUpHUD[1].SetActive(true);
                break;

            case 0:
                PowerUpHUD[2].SetActive(true);
                break;

            default:
                DisableHUDPU();
                break;

        }
    }

    void PU(){
        if(count >= 0)HUDpowerUp();
        if(ResetHudPU == true){
            HUDpowerUp();
        }
    }

        //Define parametros para colisão
        public void OnTriggerEnter(Collider other){
            if (other.gameObject.CompareTag("Enemy")&& AtvBolha == false){
                life--;
                MenosLife();
                Blink();
            }



            if (other.gameObject.CompareTag("BulletEnemy")&& AtvBolha == false){
                life-= 4;
                MenosLife();
            Blink();
                
            }

            if (other.gameObject.CompareTag("FinalBoss")&& AtvBolha == false){
                life-= 6;
                MenosLife();
                Blink();

            }

            if (other.gameObject.CompareTag("Raio")){
                life-= 3;
                MenosLife();
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
                            PU();
                            Destroy(other.gameObject);
                            //Debug.Log("Nao");
                            if (count <= 0)count = 0;

                        break;

                    case Item.TYPES.LIFE:

                            if(life<6) {
                                life++;
                                MaisLife();
                            }


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