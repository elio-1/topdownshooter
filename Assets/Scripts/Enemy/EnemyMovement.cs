using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    Transform player;
    private Rigidbody2D rb2D;

    private Vector2 _direction;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void Update()
    {
        _direction = player.transform.position - transform.position;
        Flip();
    }

    private void FixedUpdate()
    {
        rb2D.velocity = _direction.normalized * enemyData.speed * Time.deltaTime;
    }

    private void Flip()
    {
        if (_direction.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }

    
}
