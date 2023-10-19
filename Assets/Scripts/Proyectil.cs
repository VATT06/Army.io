using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public PlayerMovement playerMovement;


    void Update()
    {
        transform.Translate(Vector2.up * playerMovement.BulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) //Llamada de Dano
    {

        if (other.CompareTag("Enemigo") || other.CompareTag("Farmers"))
        {
            Debug.Log("Causo dano");
        }
    }
}
