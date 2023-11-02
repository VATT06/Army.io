using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleDestruc : ItemDestructable
{
    //Se destruye con 5 golpes bases
    //Da 25 puntos
    //public PlayerMovement Bala;
    //public float life = 15f;
    //public float experience;
    //public float damage = 1.5f;
    //private float tiempo;
    //private Animator Anim;

    //void Start()
    //{
    //    Anim = GetComponent<Animator>();
    //}

    //// Update is called once per frame
    //private void FixedUpdate()
    //{
    //    if (life <= 0)
    //    {
    //        Anim.SetBool("Death", true);
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
    //            Debug.Log("El jugador Impacto en el Triangulo.");
    //            life -= Bala.BodyDamage;
    //            Bala.MaxHealth -= damage;
    //            tiempo = 0f;
    //        }
    //        if (life <= 0)
    //        {
    //            Anim.SetBool("Death", true);
    //            Destroy(this);
                
    //        }
    //    }
    //}
}
