using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausado : MonoBehaviour
{

    [SerializeField] private GameObject menuPausado;
    

    private bool Juegopausado = false;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Juegopausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
        
    }



    public void Pausa() 
    {
        Juegopausado = true;
        Time.timeScale = 0f;
        menuPausado.SetActive(true);
    }


    public void Reanudar() 
    {
        Juegopausado = false;
        Time.timeScale = 1f;
        menuPausado.SetActive(false);
    }


    public void Reiniciar()
    {
        Juegopausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
