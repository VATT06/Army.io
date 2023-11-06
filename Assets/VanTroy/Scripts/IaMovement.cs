using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IaMovement : MonoBehaviour
{
    public List<GameObject> Resources = new List<GameObject>();
    public GameObject[] FarmersInScene = new GameObject[] { };
    public GameObject player;
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
    public float alcanceDisparo = 9f;
    public float distanciaAlObjetivo = 0f;

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
        Stats();
        FindResourcesInScene();
    }

    private void FixedUpdate()
    {
        PersuitPlayer();
    }

    private void SelectedDirection()
    {
        if (standbyMode == true && objetivo == null)
        {
            int indexObjetivo = Random.Range(0, Resources.Count);
            objetivo = Resources[indexObjetivo].gameObject;
        }
        Direction = new Vector2(objetivo.transform.position.x - transform.position.x,
            objetivo.transform.position.y - transform.position.y).normalized;

        float anguloRadianes = Mathf.Atan2(objetivo.transform.position.y - transform.position.y, objetivo.transform.position.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
        distanciaAlObjetivo = PlayerDistance();
        Debug.Log(distanciaAlObjetivo);
    }

    private void PersuitPlayer()
    {
        if (distanciaAlObjetivo < alcanceDisparo && currentHealth >= 50f)
        {
            standbyMode = false;
            persuitMode = true;
            objetivo = player;
            rb2d.MovePosition(rb2d.position + Direction * Velocity * Time.fixedDeltaTime);
            if (distanciaAlObjetivo > alcanceDisparo) { standbyMode = true; objetivo = null; }
        }
        if (distanciaAlObjetivo < alcanceDisparo && currentHealth < 50)
        {
            persuitMode = false;
            runawayMode = true;
            objetivo = player;
            rb2d.MovePosition(rb2d.position + Direction * Velocity * Time.fixedDeltaTime * -1);
            if (distanciaAlObjetivo > alcanceDisparo) { standbyMode = true; objetivo = null; }
        }
        // Agrega un caso para volver a standbyMode cuando corresponda.
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
        Vector3 distanciaAlPlayer = objetivo.transform.position - transform.position;
        float distance = distanciaAlPlayer.magnitude;
        return distance;
    }

    public void FindResourcesInScene()
    {
        Resources.Capacity = FarmersInScene.Length;
        Resources = FarmersInScene.ToList<GameObject>();
    }
}
