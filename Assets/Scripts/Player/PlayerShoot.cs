using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Weapon _currentWeapon;
    [SerializeField] Transform _barrel;
    [SerializeField] Transform _barrelParent;


    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
           Instantiate(_currentWeapon.projectile, _barrel.position, _barrelParent.localRotation);

        }


    }
}
