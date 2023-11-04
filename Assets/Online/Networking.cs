using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Networking : MonoBehaviourPunCallbacks
{
    public GameObject jugador;
    public bool IsConnected;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        IsConnected = true;
    }

    public void IngresarAlJuego()
    {
        if (!IsConnected)
            PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        DontDestroyOnLoad(PhotonNetwork.Instantiate(jugador.name, Vector3.zero, Quaternion.identity));
        PhotonNetwork.LoadLevel(1);
    }
}
