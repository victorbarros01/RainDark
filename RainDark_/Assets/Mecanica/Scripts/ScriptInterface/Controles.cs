using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour
{
    player Player;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            MovCena1();
        }
    }


    public void MovCena1()
    {
        SceneManager.LoadScene("Jogo");
    }
    
    public void MovMenu()
    {
        SceneManager.LoadScene("Abertura");
        Player.Over = 1;
    }

    public void MovCena2()
    {
        SceneManager.LoadScene("Fase2");
    }

    public void MovCena3()
    {
        SceneManager.LoadScene("Fase3");
    }
}
