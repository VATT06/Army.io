using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviourPun
{
    [SerializeField] private Transform disparador;

    public PlayerMovement playerMovement;
    private float UltimoDisparo = 0f;
    //public AudioClip ShootSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!photonView.IsMine) return;

        UltimoDisparo += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (UltimoDisparo >= playerMovement.Reload)
            {
                Disparar();
                audioSource.Play();
                
                photonView.RPC(nameof(Disparar), RpcTarget.Others);
            }
        }
    }

    [PunRPC]
    public void Disparar()
    {
        BalaPool.instance.GetBala(playerMovement, disparador);
        UltimoDisparo = 0f;
    }
}
