using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected int health;
    protected float speed = 10f;
    protected float damageOnHit;

    void Init(EnemyTemplate template)
    {
        health = template.health;
        speed = template.speed;
        damageOnHit = template.damage;
    }
}
