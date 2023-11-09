using System.Collections.Generic;
using UnityEngine;

public class IaDisparador : MonoBehaviour
{
    [SerializeField] private List<GameObject> disparadores = new List<GameObject>();
    [SerializeField] private GameObject proyectil;
    public IaMovement IaMovement;
    public SniperMovement sniperEnemy;
    public DoubleMovement doubleEnemy;
    public CarrierMovement carrierEnemy;
   // public IaProyectil velocidad;
    private float UltimoDisparo = 0f;
    private float Countdown = 0f;

    private void Start()
    {
        //velocidad.BaseEnemy = IaMovement;
        //velocidad.SniperEnemy = sniperEnemy;
        //velocidad.DoubleEnemy = doubleEnemy;
        //velocidad.CarrierEnemy = carrierEnemy;
        //IaMovement = gameObject.transform.parent.transform.GetComponentInParent<IaMovement>();
        //UnityEngine.Debug.Log("Nombre del enemigo: " + IaMovement.gameObject.name);

    }
    void Update()
    {
        SeleccionScriptMovimiento();

    }

    private void SeleccionScriptMovimiento()
    {
        UltimoDisparo += Time.deltaTime;
        Countdown += Time.deltaTime;

        if (this.IaMovement != null)
        {
            Debug.Log("ScriptDisparador>>>>Entre>>>BASE");
            //velocidad.BaseEnemy = this.IaMovement;
            Debug.Log($@"ScriptDisparador>>>>Asigne velocidad: {IaMovement.BulletSpeed} al script proyectil ");

            if (IaMovement.distanciaAlObjetivo < IaMovement.alcanceDisparo)
            {
                Debug.Log("ScriptDisparador>>>>Objetivo dentro del alcance");

                if (UltimoDisparo >= IaMovement.Reload)
                {
                    Debug.Log("ScriptDisparador>>>>Tiempo de recarga dentro de los parametros");

                    Disparar();
                    Debug.Log("ScriptDisparador>>>>DISPARE>>>>BASE");

                    if (Countdown >= IaMovement.Reload)
                    {
                        UltimoDisparo = 0f;
                    }
                }
            }

        }

        //else if (this.sniperEnemy != null)
        //{
        //    Debug.Log("ScriptDisparador>>>>Entre>>>SNIPER");
        //    velocidad.SniperEnemy = this.sniperEnemy;
        //    Debug.Log($@"ScriptDisparador>>>>Asigne velocidad: {velocidad.BaseEnemy} al script proyectil ");

        //    if (sniperEnemy.distanciaAlObjetivo < sniperEnemy.alcanceDisparo)
        //    {
        //        Debug.Log("ScriptDisparador>>>>Objetivo dentro del alcance");

        //        if (UltimoDisparo >= sniperEnemy.Reload)
        //        {
        //            Debug.Log("ScriptDisparador>>>>Tiempo de recarga dentro de los parametros");

        //            Disparar();
        //            Debug.Log("ScriptDisparador>>>>DISPARE>>>>SNIPER");

        //            if (Countdown >= sniperEnemy.Reload)
        //            {
        //                UltimoDisparo = 0f;
        //            }
        //        }
        //    }
        //}

        //else if (this.doubleEnemy != null)
        //{
        //    Debug.Log("ScriptDisparador>>>>Entre>>>DOUBLE");

        //    if (doubleEnemy.distanciaAlObjetivo < doubleEnemy.alcanceDisparo)
        //    {
        //        Debug.Log("ScriptDisparador>>>>Objetivo dentro del alcance");

        //        if (UltimoDisparo >= doubleEnemy.Reload)
        //        {
        //            Debug.Log("ScriptDisparador>>>>Tiempo de recarga dentro de los parametros");

        //            Disparar();
        //            Debug.Log("ScriptDisparador>>>>DISPARE>>>>DOUBLE");
        //            velocidad.DoubleEnemy.BulletSpeed = doubleEnemy.BulletSpeed;
        //            Debug.Log($@"ScriptDisparador>>>>Asigne velocidad: {velocidad.DoubleEnemy.BulletSpeed} al script proyectil ");

        //            if (Countdown >= doubleEnemy.Reload)
        //            {
        //                UltimoDisparo = 0f;
        //            }
        //        }
        //    }
        //}

        //else if (this.carrierEnemy != null)
        //{
        //    Debug.Log("ScriptDisparador>>>>Entre>>>CARRIER");

        //    velocidad.CarrierEnemy = this.carrierEnemy;
        //    Debug.Log($@"ScriptDisparador>>>>Asigne velocidad: {velocidad.BaseEnemy} al script proyectil ");

        //    if (carrierEnemy.distanciaAlObjetivo < carrierEnemy.alcanceDisparo)
        //    {
        //        Debug.Log("ScriptDisparador>>>>Objetivo dentro del alcance");

        //        if (UltimoDisparo >= carrierEnemy.Reload)
        //        {
        //            Debug.Log("ScriptDisparador>>>>Tiempo de recarga dentro de los parametros");

        //            Disparar();
        //            Debug.Log("ScriptDisparador>>>>DISPARE>>>>CARRIER");

        //            if (Countdown >= carrierEnemy.Reload)
        //            {
        //                UltimoDisparo = 0f;
        //            }
        //        }
        //    }
        //}

        else { Debug.Log("Sin script de movimiento en el disparador"); }
    }

    private void Disparar()
    {

        int randomIndexTrigger = Random.Range(0, disparadores.Count);
        Instantiate(proyectil, disparadores[randomIndexTrigger].transform.position, disparadores[randomIndexTrigger].transform.rotation);
    }
}
