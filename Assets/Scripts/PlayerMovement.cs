using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviourPun
{
    [Header("Stats")]
    public int Level = 1;
    public int PuntosStats = 0;
    public float Score;
    private int ScoreNextLevel = 10;
    public float MaxHealth = 10f, HealthRegen, Health;
    private float RegenSecond, RegenCooldown;
    public float BodyDamage = 2f;
    public float BulletSpeed, BulletPenetration, BulletDamage = 2f;
    public float Reload = 2f;
    public float Velocity = 3f;
    public TextMeshProUGUI[] Estadisticas;
    public TextMeshProUGUI Nivel;
    public TextMeshProUGUI Puntos;
    public TextMeshProUGUI StatsPointNum, StatsPoint;

    [Header("Ui In Game")]
    public GameObject Stadistics;
    public GameObject Clase;
    public Button Sniper;
    public Button[] StatsButton;


    //Niveles de Stats
    private float LevelMaxHealth;
    private float LevelHealthRegen;
    private float LevelBodyDamage;
    private float LevelBulletSpeed;
    private float LevelBulletPenetration;
    private float LevelBulletDamage;
    private float LevelReload;
    private float LevelVelocity;
    public bool etapa1 = false;
    public bool etapa2 = false;
    public ClassManager ClassManager;

    [Header("Movement")]
    private Rigidbody2D rb2d;
    public float velocidadRotacion = 500f;
    public float velocidadMovimiento = 5f;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }


    void Update()
    {
        RotarPersonaje();
        

        Stats();

        if (MaxHealth <= 0f)
        {
            this.gameObject.SetActive(false);
            Destroy(this);
        }

        if (Input.anyKeyDown && PuntosStats >= 1)
        {
            for (KeyCode key = KeyCode.Alpha1; key <= KeyCode.Alpha8; key++)
            {
                if (Input.GetKeyDown(key))
                    TeclaPresionada(key);
            }
        }
    }


    private void FixedUpdate()
    {
        
    }
    
    void RotarPersonaje()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector2 direccionMovimiento = new Vector2(inputHorizontal, inputVertical);
        float inputMagnitud = Mathf.Clamp01(direccionMovimiento.magnitude);
        direccionMovimiento.Normalize();

        transform.Translate(direccionMovimiento * Velocity * inputMagnitud * Time.deltaTime, Space.World);

        if (direccionMovimiento != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(transform.forward, direccionMovimiento);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, velocidadRotacion * Time.deltaTime);
            
        }
    }
    public void Stats()
    {
        LevelUp();
    }
    public void TeclaPresionada(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.Alpha1: HPRegen(); break;
            case KeyCode.Alpha2: MaxHP(); break;
            case KeyCode.Alpha3: BodyDam(); break;
            case KeyCode.Alpha4: BulletFast(); break;
            case KeyCode.Alpha5: BulletPen(); break;
            case KeyCode.Alpha6: BulletDam(); break;
            case KeyCode.Alpha7: Reloaded(); break;
            case KeyCode.Alpha8: MovementSpeed(); break;
        }
    }

    private void LevelUp()
    {
        if (Score >= ScoreNextLevel)
        {
            Level += 1;
            PuntosStats += 1;
            ScoreNextLevel *= 2;
        }
        StatsPoint.text = PuntosStats.ToString();
        Nivel.text = Level.ToString();
        Puntos.text = Score.ToString();
    }

    public void HPRegen()
    {
        RegenSecond += Time.deltaTime;
        RegenCooldown += Time.deltaTime;
        //Se activa con la tecla 1
        if (PuntosStats >= 1)
        {
            LevelHealthRegen += 1;
            if (LevelHealthRegen >= 10)
            {
                LevelHealthRegen = 10;
            }
            if (RegenSecond >= RegenCooldown)
            {
                Health += HealthRegen;
            }
            PuntosStats -= 1;
            Estadisticas[0].text = LevelHealthRegen.ToString();

        }
    }

    public void MaxHP()
    {
        //Se activa con la tecla 2
        if (PuntosStats >= 1)
        {
            LevelMaxHealth += 1;

            if (LevelMaxHealth >= 10)
            {
                LevelMaxHealth = 10;
            }
            PuntosStats -= 1;
            Estadisticas[1].text = LevelMaxHealth.ToString();
        }
    }

    public void BodyDam()
    {
        //Se activa con la tecla 3
        if (PuntosStats >= 1)
        {
            LevelBodyDamage += 1;

            if (LevelBodyDamage >= 10)
            {
                LevelBodyDamage = 10;
            }
            PuntosStats -= 1;
            Estadisticas[2].text = LevelBodyDamage.ToString();
        }
    }

    public void BulletFast()
    {
        //Se activa con la tecla 4
        if (PuntosStats >= 1)
        {
            LevelBulletSpeed += 1;

            Debug.Log("Haz aumentado la Bullet Speed del arma");
            BulletSpeed += 0.5f;
            if (BulletSpeed >= 15f)
            {
                BulletSpeed = 15f;
                Debug.Log("la Bullet Speed esta al MAXIMO");
            }
            if (LevelBulletSpeed >= 10)
            {
                LevelBulletSpeed = 10;
            }
            PuntosStats -= 1;
            Estadisticas[3].text = LevelBulletSpeed.ToString();
        }
    }

    public void BulletPen()
    {
        //Se activa con la tecla 5
        if (PuntosStats >= 1)
        {
            LevelBulletPenetration += 1;

            if (LevelBulletPenetration >= 10)
            {
                LevelBulletPenetration = 10;
            }
            PuntosStats -= 1;
            Estadisticas[4].text = LevelBulletPenetration.ToString();
        }
    }

    public void BulletDam()
    {
        //Se activa con la tecla 6
        if (PuntosStats >= 1)
        {
            LevelBulletDamage += 1;
            if (LevelBulletDamage >= 10)
            {
                LevelBulletDamage = 10;
            }
            PuntosStats -= 1;
            Estadisticas[5].text = LevelBulletDamage.ToString();
        }
    }

    public void Reloaded()
    {
        //Se activa con la tecla 7
        if (PuntosStats >= 1)
        {
            LevelReload += 1;
            Debug.Log("Haz reducido el RELOAD del arma");
            Reload -= 0.2f;
            if (Reload <= 0.2f)
            {
                Reload = 0.2f;
                Debug.Log("el RELOAD esta al MAXIMO");
            }
            if (LevelReload >= 10)
            {
                LevelReload = 10;
            }
            PuntosStats -= 1;
            Estadisticas[6].text = LevelReload.ToString();
        }
    }

    public void MovementSpeed()
    {
        //Se activa con la tecla 8
        if (PuntosStats >= 1)
        {
            LevelVelocity += 1;
            Debug.Log("Haz aumentado tu Movement Speed");
            Velocity += 0.5f;
            if (Velocity >= 15f)
            {
                Velocity = 15f;
                Debug.Log("el Movement Speed esta al MAXIMO");
            }
            if (LevelVelocity >= 10)
            {
                LevelVelocity = 10;
            }
            PuntosStats -= 1;
            Estadisticas[7].text = LevelVelocity.ToString();
        }
    }
}
