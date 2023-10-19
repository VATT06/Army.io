using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public float Level;
    public float MaxHealth, HealthRegen;
    public float BodyDamage;
    public float BulletSpeed = 0f, BulletPenetration, BulletDamage;
    public float Reload = 2f;
    public float Velocity = 3f;

    [Header("Movement")]
    [SerializeField] private Vector2 Direction;
    [SerializeField] private Vector3 objetivo;
    [SerializeField] private Camera camara;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        objetivo = camara.ScreenToWorldPoint(Input.mousePosition);
        float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
        Stats();
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + Direction * Velocity * Time.fixedDeltaTime);
    }

    public void Stats()
    {
        BulletFast();
        Reloaded();
        MovementSpeed();
    }

    private void BulletFast()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6)  && BulletSpeed < 15f)
        {
            Debug.Log("Haz aumentado la Bullet Speed del arma");
            BulletSpeed += 0.5f;
            if (BulletSpeed >= 15f)
            {
                BulletSpeed = 15f;
                Debug.Log("la Bullet Speed esta al MAXIMO");
            }
        }
        
    }

    private void Reloaded()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7) && Reload > 0.5f)
        {
            Debug.Log("Haz reducido el RELOAD del arma");
            Reload -= 0.5f;
            if (Reload <= 0.4f)
            {
                Reload = 0.1f;
                Debug.Log("el RELOAD esta al MAXIMO");
            }
        }
    }

    private void MovementSpeed()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8) && Velocity < 15f)
        {
            Debug.Log("Haz aumentado tu Movement Speed");
            Velocity += 0.5f;
            if (Velocity >= 15f)
            {
                Velocity = 15f;
                Debug.Log("el Movement Speed esta al MAXIMO");
            }
        }
    }
}
