using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Enemy
{
    [SerializeField] Transform _attackPoint;
    [SerializeField] float _radius;
    [SerializeField] LayerMask _playerLayer;
    private void Update()
    {
        Collider2D attackCol = Physics2D.OverlapCircle(_attackPoint.transform.position, _radius, 0, _playerLayer);
        if (attackCol != null)
        {
            Debug.Log("PlayerHit");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
