using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameManagement : MonoBehaviour
{
    public void Exit() 
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }

    public void DeVueltaAlMenu()
    {
        SceneManager.LoadScene("Carlos_Scene");
    }
}
