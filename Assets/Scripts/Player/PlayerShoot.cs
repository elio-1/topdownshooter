using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Weapon currentWeapon;
    [SerializeField] Transform _barrel;
    [SerializeField] Transform _barrelParent;
    

    void FixedUpdate()
    {
        GameObject bullet = BulletPooling.m_BulletInstance.GetBulletObject();
        if (Input.GetMouseButton(0))
        {
            if (bullet != null)
            {
                bullet.transform.position = _barrel.position;
                bullet.transform.rotation = _barrelParent.localRotation;
                bullet.SetActive(true);
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            
            GameObject.Find("Pooling").GetComponent<BulletPooling>().ChangeActiveBullet(currentWeapon.bulletName);
        }

    }
}
