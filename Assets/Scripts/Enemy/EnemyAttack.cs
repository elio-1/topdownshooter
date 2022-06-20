using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Enemy
{
    [SerializeField] Transform _attackPoint;
    [SerializeField] float _radius;
    [SerializeField] LayerMask _playerLayer;
    float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        Collider2D attackCol = Physics2D.OverlapCircle(_attackPoint.transform.position, _radius, _playerLayer);
        if (attackCol != null)
        {
            Debug.Log("hit");

            if ( timer > enemyData.attackSpeed )
            {
                int playercurrenthealth = attackCol.GetComponent<PlayerHealth>().currentHealth -= enemyData.baseAttack;
                Debug.Log(playercurrenthealth);
                timer = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
