using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
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
                PausaMenu();
            }
        }
    }

    public void PausaMenu()
    {
        PausaMenu.SetActive(true);
        Time.timescale = 0f;
        IsPaused = true;
    }
       
    public void ResumirJogo()
    {
        PausaMenu.SetActive(false);
        Time.timescale = 1f;
        IsPaused = false;
    }

    public void MenuPrincipal()
    {
        Time.TimeScale = 1f;
        SceneManager.LoadScene("Abertura");
    }

    public void Sair()
    {
        Application.Sair();
    }
}
