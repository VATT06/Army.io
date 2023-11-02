using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BalaPool : MonoBehaviour
{
    public static BalaPool instance
    {
        get; private set;
    }
    public GameObject balaPrefab;

    List<GameObject> balaList = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public GameObject GetBala(PlayerMovement parent, Transform spawn)
    {
        GameObject toReturn = balaList.Find(bala => bala.activeInHierarchy == false);

        if (toReturn == null)
        {
            toReturn = Instantiate(balaPrefab);
            balaList.Add(toReturn);
        }
        toReturn.SetActive(true);
        toReturn.transform.SetPositionAndRotation(spawn.position, spawn.rotation);
        toReturn.GetComponent<Proyectil>().Nacer(parent);
        return toReturn;
    }
    public GameObject GetBala(Vector3 pos, PlayerMovement parent)
    {
        GameObject toReturn = balaList.Find(bala => bala.activeInHierarchy == false);
        if(toReturn == null)
        {
            toReturn = Instantiate(balaPrefab, pos, Quaternion.identity);
            balaList.Add(toReturn);
        }
        toReturn.GetComponent<Proyectil>().Nacer(parent);
        return toReturn;
    }
}
