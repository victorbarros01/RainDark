using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCena : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            MovCena1();
            MovCena2();
        }
    }

    public void MovCena1()
    {
        SceneManager.LoadScene("Fase2");
    }

    public void MovCena2()
    {
        SceneManager.LoadScene("Fase3");
    }
}
