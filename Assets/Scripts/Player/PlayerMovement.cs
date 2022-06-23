using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Vector2 _direction;
    [SerializeField] Character playerData;

    private void Awake()
    {
        playerData.speed = 100;
        playerData.baseAttack = 0;
        playerData.baseDefence = 0;

    }
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
