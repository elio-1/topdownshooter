using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Weapon currentWeapon;
    [SerializeField] Transform _barrel;
    [SerializeField] Transform _barrelParent;

    float _shakeMagnitude;
    float _shakeRoughness;
    float _shakeFadeInTime;
    float _shakeFadeOutTime;
    float _timer = 0 ;
    float _fireRate;


   // SpriteRenderer SpriteRenderer;

    private void Awake()
    {
       // SpriteRenderer = _barrelParent.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        _shakeMagnitude = currentWeapon.shakeMagnitude;
        //SpriteRenderer.sprite = currentWeapon.skin;
        _shakeRoughness = currentWeapon.shakeRoughness;
        _shakeFadeInTime = currentWeapon.shakeFadeInTime;
        _shakeFadeOutTime = currentWeapon.shakeFadeOutTime;
        _fireRate = currentWeapon.fireRate;
        _timer += Time.deltaTime;
            GameObject bullet = BulletPooling.m_BulletInstance.GetBulletObject();
        if (Input.GetMouseButton(0) && _timer > _fireRate)
        {
            if (bullet != null)
            {
                EZCameraShake.CameraShaker.Instance.ShakeOnce(_shakeMagnitude, _shakeRoughness, _shakeFadeInTime, _shakeFadeOutTime);
                bullet.transform.position = _barrel.position;
                bullet.transform.rotation = _barrelParent.localRotation;
                bullet.SetActive(true);
                _timer = 0;
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            ChangeWeapon();
            
        }
    }
    void ChangeWeapon()
    {
        

        GameObject.Find("BulletPooling").GetComponent<BulletPooling>().ChangeActiveBullet(currentWeapon.bulletName);
    }
}
