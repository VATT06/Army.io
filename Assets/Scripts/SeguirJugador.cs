using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform Jugador;
    void Update()
    {
        if (Jugador != null)
        {
            Vector3 posicionObjetivo = new Vector3(Jugador.position.x, Jugador.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, Time.deltaTime * 5);
        }
    }
}
