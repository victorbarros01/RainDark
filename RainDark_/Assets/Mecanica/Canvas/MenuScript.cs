using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
   public void MovCena(){
       SceneManager.LoadScene("Jogo");
   }
    public void SairJogo()
    {
        Application.Quit();
    }
}

