using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviourPunCallbacks
{
    public Transform[] SpawnRojo, SpawnAzul;

    public GameObject jugadorPrefab;
    public void NuevoJugador()
    {
        bool team = Random.Range(0, 2) == 1;
        Vector3 spawnPos = Vector3.zero;   
        if (team)
        {
            spawnPos = SpawnRojo[Random.Range(0, SpawnRojo.Length)].position;
        }
        else
        {
            spawnPos = SpawnAzul[Random.Range(0, SpawnAzul.Length)].position;

        }

        PhotonNetwork.Instantiate(jugadorPrefab.name, spawnPos, Quaternion.identity);
    }

    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            NuevoJugador();
        }
    }

    
    void Update()
    {
        
    }
}


public enum Equipo
{
    None, Rojo, Azul
}