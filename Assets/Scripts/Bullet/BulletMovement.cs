using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] Weapon bulletData;
    void Start()
    {
        rb2D.AddForce(transform.right * bulletData.bulletSpeed);
    }
}
