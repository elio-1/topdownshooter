using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    Rigidbody2D rigidbody2d;
    Vector2 _direction;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
       
    }

   
    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal"); 
        _direction.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = _direction.normalized * playerData.speed * Time.deltaTime;
    }
}
