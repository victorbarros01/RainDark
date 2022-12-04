using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject Boss;


    void Update(){
        if(Boss == null){
            Invoke(nameof(Next), 3.0f);
        }

    }

    void Next(){
        SceneManager.LoadScene("CenaLoad");
    }
}

