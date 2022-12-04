using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScriptPause : MonoBehaviour
{
    public GameObject PausaMenu;
    public bool IsPaused;
    

    // Start is called before the first frame update
    void Start()
    {
        PausaMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                ResumirJogo();
            }
            else
            {
                PauseMenu();
            }
        }
    }

    public void PauseMenu()
    {
        PausaMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
       
    public void ResumirJogo()
    {
        PausaMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Abertura");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
