using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            EnemyBase enemy = other.GetComponent<EnemyBase>();
            enemy.HitEnemy(transform.position);
        }
    }
}
