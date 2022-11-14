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
            MovCena();
        }
    }

    public void MovCena()
    {
        SceneManager.LoadScene("CenaLoad");
    }
}
