using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Proyectil : MonoBehaviourPun
{
    public PlayerMovement playerMovement;
    public float life = 0.5f;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        life += playerMovement.BulletPenetration;
        transform.Translate(Vector2.up * playerMovement.BulletSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(Morir), 5);
    }
    void Morir()
    {
        gameObject.SetActive(false);
    }
    public void Nacer(PlayerMovement padre)
    {
        playerMovement = padre;
    }
    private void OnTriggerEnter2D(Collider2D other) //Llamada de Dano
    {
        if (other.TryGetComponent<ItemDestructable>(out var cuadrado))
        {
            life -= cuadrado.damage;

            cuadrado.life -= playerMovement.BulletDamage + playerMovement.BulletPenetration;
            if (life <= 0f)
            {
                anim.SetBool("Death", true);
                Destroy(this);
            }
            if (cuadrado.life <= 0f)
            {
                playerMovement.Score += cuadrado.experience;
            }
        }
        //if (other.CompareTag("TrianDest") && TryGetComponent<TriangleDestruc>(out var triangulo))
        //{
        //    Debug.Log("Triangulo");
        //    life -= Triangle.damage;

        //    Debug.Log("La Bala Impacto en el Triangulo.");
        //    Triangle.life -= playerMovement.BulletDamage + playerMovement.BulletPenetration;
        //    if (life <= 0f)
        //    {
        //        anim.SetBool("Death", true);
        //        Destroy(this);
        //    }
        //    if (Triangle.life <= 0f)
        //    {
        //        playerMovement.Score += Triangle.experience;
        //    }
        //}
        //if (other.CompareTag("HexaDest"))
        //{
        //    Debug.Log("Hexagono");
        //    life -= Hexagon.damage;

        //    Debug.Log("La Bala Impacto en el Hexagono.");
        //    Hexagon.life -= playerMovement.BulletDamage + playerMovement.BulletPenetration;
        //    if (life <= 0f)
        //    {
        //        anim.SetBool("Death", true);
        //        Destroy(this);
        //    }
        //    if (Hexagon.life <= 0f)
        //    {
        //        playerMovement.Score += Hexagon.experience;
        //    }
        //}
    }
}
