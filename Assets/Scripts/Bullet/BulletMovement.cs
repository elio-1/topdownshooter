using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] Weapon bulletData;
    Transform _player;
    [SerializeField] Character playerData;
    public GameObject[] m_bulletsGO;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if ((transform.position - _player.transform.position).magnitude > 15)
        {
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        rb2D.velocity = transform.right * PlayerShoot.currentWeapon.bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().currentHealth -= (bulletData.damage + playerData.baseAttack);
             gameObject.SetActive(false);
        }
    }
}
