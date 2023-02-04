using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int health;
    float speed;
    float damageOnHit;

    void Init(EnemyTemplate template)
    {
        health = template.health;
        speed = template.speed;
        damageOnHit = template.damage;
    }
}
