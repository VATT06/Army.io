using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaDisparador : MonoBehaviour
{
    [SerializeField] private Transform disparador;
    [SerializeField] private GameObject proyectil;
    public IaMovement IaMovement;
    private float UltimoDisparo = 0f;
    private float Countdown = 0f;

    private void Start()
    {
        IaMovement=GetComponentInParent<IaMovement>();
    }
    void Update()
    {
        UltimoDisparo += Time.deltaTime;
        Countdown += Time.deltaTime;

        if (IaMovement.distanciaAlObjetivo<IaMovement.alcanceDisparo)
        {
            if (UltimoDisparo >= IaMovement.Reload)
            {
                Disparar();
                if (Countdown >= IaMovement.Reload)
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
