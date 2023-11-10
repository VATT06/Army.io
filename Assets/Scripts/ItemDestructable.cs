using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestructable : MonoBehaviourPun
{
    public PlayerMovement Bala;
    public float life = 4f;
    public float experience;
    public float damage = 0.6f;
    private float tiempo;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (life <= 0)
        {
            anim.SetBool("Death", true);
            //Destroy(this.gameObject);
            Destroy(this);

        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            tiempo += Time.deltaTime;

            if (tiempo > 0.5f)
            {
                Debug.Log($"El jugador Impacto en el {gameObject.name}.");
                life -= Bala.BodyDamage;
                Bala.MaxHealth -= damage;
                tiempo = 0f;
            }
            if (life <= 0)
            {
                anim.SetBool("Death", true);
                //Destroy(this.gameObject);
                Destroy(this);
            }
        }

    }
}
