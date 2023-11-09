using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="IA_Stadistics",menuName ="Ia_ScriptableObjects")]
public class IaStats : ScriptableObject
{
    [SerializeField] GameObject enemy;
    public float Level = 0f;
    public float MaxHealth = 0f;
    public float HealthRegen = 0f;
    public float currentHealth = 0f;
    public float BodyDamage = 0f;
    public float BulletSpeed = 0f;
    public float BulletPenetration = 0f; 
    public float BulletDamage = 0f;
    public float Reload = 0f;
    public float Velocity = 0f;
    public float alcanceDisparo = 0f;
    public float distanciaEstacionamiento_Resources = 0f;
}
