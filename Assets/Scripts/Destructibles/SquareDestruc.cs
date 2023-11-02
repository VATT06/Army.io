using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SquareDestruc : ItemDestructable
{
    //Se destruye con 2 golpes bases
    //Da 10 puntos
    //public PlayerMovement Bala;
    //public float life = 4f;
    //public float experience;
    //public float damage = 0.6f;
    //private float tiempo;
    //private Animator anim;

    //private void Start()
    //{
    //    anim = GetComponent<Animator>();
    //}

    //private void FixedUpdate()
    //{
    //    if (life <= 0)
    //    {
    //        anim.SetBool("Death", true);
    //        Destroy(this);
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Jugador"))
    //    {
    //        tiempo += Time.deltaTime;
            
    //        if (tiempo > 0.5f)
    //        {
    //            Debug.Log("El jugador Impacto en el Cuadrado.");
    //            life -= Bala.BodyDamage;
    //            Bala.MaxHealth -= damage;
    //            tiempo = 0f;
    //        }
    //        if (life <= 0)
    //        {
    //            anim.SetBool("Death", true);
    //            Destroy(this);
    //        }
    //    }
    //}

}
