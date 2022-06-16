using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] Weapon bulletData;
    PlayerShoot PlayerShoot;
    [SerializeField] Character playerData;
    public GameObject[] m_bulletsGO;

    private void Awake()
    {
        PlayerShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>();
    }
    private void Update()
    {
        if ((transform.position - PlayerShoot.transform.position).magnitude > 10)
        {
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        rb2D.velocity = transform.right * PlayerShoot.currentWeapon.bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().currentHealth -= (bulletData.damage + playerData.baseAttack);
        }
    }
}
