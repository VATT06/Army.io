using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    [SerializeField] private Transform disparador;
    [SerializeField] private GameObject proyectil;
    public PlayerMovement playerMovement;
    private float UltimoDisparo = 0f;
    private float Countdown = 0f;

    void Update()
    {
        UltimoDisparo += Time.deltaTime;
        Countdown += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            if (UltimoDisparo >= playerMovement.Reload)
            {
                Disparar();
                if (Countdown >= playerMovement.Reload)
                {
                    UltimoDisparo = 0f;
                }
            }
        }
    }

    private void Disparar()
    {
        Instantiate(proyectil, disparador.position, disparador.rotation);
    }
}
