using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaProyectil : MonoBehaviour
{
    public IaMovement IaMovement;

    private void Start()
    {
        //IaMovement=FindObjectOfType<IaMovement>();
    }
    void Update()
    {
        transform.Translate(Vector2.up * IaMovement.BulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) //Llamada de Dano
    {

        if (other.CompareTag("Player") || other.CompareTag("Farmers"))
        {
            Debug.Log("Causo dano");
        }
    }
}
