using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Enemy
{
    [SerializeField] Transform _attackPoint;
    [SerializeField] float _radius;
    [SerializeField] LayerMask _playerLayer;
    [SerializeField] Character _playerData;
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
                if (_playerData.baseDefence > enemyData.baseAttack)
                {
                    return;
                }
                else
                {

                PlayerHealth.currentHealth -= (enemyData.baseAttack - _playerData.baseDefence);
                
                timer = 0;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
