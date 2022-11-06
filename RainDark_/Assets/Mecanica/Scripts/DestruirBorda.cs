using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DestruirBorda : MonoBehaviour
{
    bool life = true;
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        if(other.gameObject.CompareTag("Player")) {
            life = false;
            GameOver();
        }
    }

    void GameOver(){
        if (life == false) SceneManager.LoadScene("Game Over");
    }
}
