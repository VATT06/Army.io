using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{
    public PlayerMovement jugador;
    public GameObject stats;
    public GameObject score;
    public GameObject clase;
    public GameObject menuDead;
    public TextMeshProUGUI Record;

    // Update is called once per frame
    void Update()
    {
        if (jugador.MaxHealth < 1f)
        {
            menuDead.SetActive(true);
            
            Record.text = jugador.Score.ToString();
            clase.SetActive(false);
            score.SetActive(false);
            stats.SetActive(false);
        }
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Carlos_Scene");
    }
}
