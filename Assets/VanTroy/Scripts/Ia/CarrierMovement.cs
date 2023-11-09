using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarrierMovement : MonoBehaviour
{
    public List<GameObject> Resources = new List<GameObject>();
    public GameObject[] FarmersInScene = new GameObject[] { };
    public GameObject player;
    public GameObject farmer;
    public bool standbyMode = true;
    public bool persuitMode = false;
    public bool runawayMode = false;

    [Header("Stats")]
    public float Level;
    public float MaxHealth, HealthRegen, currentHealth = 100f;
    public float BodyDamage;
    public float BulletSpeed = 10f, BulletPenetration, BulletDamage;
    public float Reload = 2f;
    public float Velocity = 3f;
    public float alcanceDisparo = 5f;
    public float distanciaEstacionamiento_Resources = 3f;
    public float distanciaAlObjetivo;
    public float distanciaPlayer = 0f;

    [Header("Movement")]
    [SerializeField] private Vector2 Direction;
    [SerializeField] private GameObject objetivo;
    [SerializeField] private Camera camara;
    private Rigidbody2D rb2d;

    void Start()
    {
        FarmersInScene = GameObject.FindGameObjectsWithTag("Farmers");
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        SelectedDirection();
        //Stats();
        FindResourcesInScene();
    }

    private void FixedUpdate()
    {
        PersuitPlayer();
        PersuitResources();
    }

    public void SelectedDirection()
    {
        if (standbyMode == true && (objetivo == null || !objetivo.activeInHierarchy))
        {
            float distanciaMinima = float.MaxValue;
            GameObject agricultorMasCercano = null;

            foreach (GameObject agricultor in Resources)
            {
                if (!agricultor.activeInHierarchy) continue; // Saltar agricultores desactivados

                float distancia = Vector2.Distance(transform.position, agricultor.transform.position);
                if (distancia < distanciaMinima)
                {
                    distanciaMinima = distancia;
                    agricultorMasCercano = agricultor;
                }
            }

            if (agricultorMasCercano != null)
            {
                farmer = agricultorMasCercano;
                objetivo = agricultorMasCercano;
            }
        }
        Direction = new Vector2(objetivo.transform.position.x - transform.position.x,
            objetivo.transform.position.y - transform.position.y).normalized;

        float anguloRadianes = Mathf.Atan2(objetivo.transform.position.y - transform.position.y, objetivo.transform.position.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
        distanciaPlayer = PlayerDistance();
        distanciaAlObjetivo = ObjectiveDistance();
        Debug.Log("Distancia al objetivo: " + distanciaPlayer);
        Debug.Log("Distania al Player: " + distanciaAlObjetivo);
    }

    public void PersuitPlayer()
    {
        if (distanciaPlayer < alcanceDisparo && currentHealth >= 50f)
        {
            standbyMode = false;
            persuitMode = true;
            objetivo = player;
            rb2d.MovePosition(rb2d.position + Direction * Velocity * Time.fixedDeltaTime);
        }
        if (distanciaPlayer < alcanceDisparo && currentHealth < 50)
        {
            persuitMode = false;
            runawayMode = true;
            objetivo = player;
            rb2d.MovePosition(rb2d.position + Direction * Velocity * Time.fixedDeltaTime * -1);
            //if (distanciaAlObjetivo >= alcanceDisparo) { standbyMode = true; persuitMode = false; objetivo = null; }
        }
        if (distanciaPlayer > alcanceDisparo) { standbyMode = true; persuitMode = false; objetivo = null; }
        // Agrega un caso para volver a standbyMode cuando corresponda.
    }
    public void PersuitResources()
    {
        rb2d.MovePosition(rb2d.position + Direction * Velocity * Time.fixedDeltaTime);
        if (distanciaAlObjetivo < distanciaEstacionamiento_Resources)
        {
            Debug.Log("Recurso dentro del alcance");
            rb2d.MovePosition(rb2d.position + Direction * 0 * Time.fixedDeltaTime);

        }
    }

    public void Stats()
    {
        BulletFast();
        Reloaded();
        MovementSpeed();
    }

    public void BulletFast()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6) && BulletSpeed < 15f)
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

    public void Reloaded()
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

    public void MovementSpeed()
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

    public float PlayerDistance()
    {
        Vector3 distanciaAlPlayer = player.transform.position - transform.position;
        float distance = distanciaAlPlayer.magnitude;
        return distance;
    }

    public float ObjectiveDistance()
    {
        Vector3 distanciaAlObjectivo = objetivo.transform.position - transform.position;
        float distance = distanciaAlObjectivo.magnitude;
        return distance;
    }

    public void FindResourcesInScene()
    {
        Resources.Capacity = FarmersInScene.Length;
        Resources = FarmersInScene.ToList<GameObject>();
    }

}
