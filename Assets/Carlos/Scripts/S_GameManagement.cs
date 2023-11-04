using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GameManagement : MonoBehaviour
{
    public void Exit() 
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }

}
