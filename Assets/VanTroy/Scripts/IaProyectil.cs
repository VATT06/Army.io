using Photon.Pun.Demo.SlotRacer.Utils;
using UnityEngine;

public class IaProyectil : MonoBehaviour
{
    public IaMovement BaseEnemy;
    public SniperMovement SniperEnemy;
    public DoubleMovement DoubleEnemy;
    public CarrierMovement CarrierEnemy;
    public PlayerMovement player;
    //public IaMovement ia;
    public //ItemDestructable resource;
     float life = 0.5f;
    //private Animator anim;
    //public IaMovement MovementActual;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        BaseEnemy=GameObject.Find("Enemy_Base").gameObject.transform.GetComponentInChildren<Transform>().GetComponentInChildren<IaDisparador>().IaMovement;
        //SniperEnemy = GameObject.Find("Enemy_Sniper").gameObject.transform.GetComponentInChildren<Transform>().GetComponentInChildren<IaDisparador>().sniperEnemy;
        //DoubleEnemy=GameObject.Find("Enemy_Double").gameObject.transform.GetComponentInChildren<Transform>().GetComponentInChildren<IaDisparador>().doubleEnemy;
        //CarrierEnemy =GameObject.Find("Enemy_Carrier").gameObject.transform.GetComponentInChildren<Transform>().GetComponentInChildren<IaDisparador>().carrierEnemy;
    }
    void Update()
    {
        if (BaseEnemy!=null)
        {
        transform.Translate(Vector2.up * BaseEnemy.BulletSpeed * Time.deltaTime);
        }
        else { Debug.Log("Disparo Ia nulo Base_Enemy");}

        life += BaseEnemy.BulletPenetration;
        transform.Translate(Vector2.up * BaseEnemy.BulletSpeed * Time.deltaTime);
        //if (SniperEnemy != null)
        //{
        //    transform.Translate(Vector2.up * SniperEnemy.BulletSpeed * Time.deltaTime);
        //}
        //else { Debug.Log("Disparo Ia nulo Sniper_Enemy"); }

        //if (DoubleEnemy != null)
        //{
        //    transform.Translate(Vector2.up * DoubleEnemy.BulletSpeed * Time.deltaTime);
        //}
        //else { Debug.Log("Disparo Ia nulo Double_Enemy"); }

        //if (CarrierEnemy != null)
        //{
        //    transform.Translate(Vector2.up * CarrierEnemy.BulletSpeed * Time.deltaTime);
        //}
        //else { Debug.Log("Disparo Ia nulo Carrier_Enemy"); }
    }

    private void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(Morir), 5);
    }
    void Morir()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    //public void Nacer(IaMovement padre)
    //{
    //    ia = padre;
    //}
    private void OnTriggerEnter2D(Collider2D other) //Llamada de Dano
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            player=other.GetComponent<PlayerMovement>();
            player.MaxHealth -= 2.5f;
            Destroy(gameObject);
            if(player.MaxHealth < 0)
            {
                Destroy(player.gameObject);
            }
        }
        if (other.TryGetComponent<ItemDestructable>(out var resource))
        {
            Debug.LogWarning($"Choque con {resource.name}, bala ia");
            life -= resource.damage;

            resource.life -= BaseEnemy.BulletDamage + BaseEnemy.BulletPenetration;
            if (life <= 0f)
            {
                //anim.SetBool("Death", true);
                Destroy(this.gameObject);
            }
            if (resource.life <= 0f)
            {
               resource.gameObject.SetActive(false);
                BaseEnemy.Level += resource.experience;
            }
            
        }
    }
}
