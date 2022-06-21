using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static Weapon currentWeapon;
    public static int weaponLevel = 0;
    public static int weaponLevelMax;
    [SerializeField] Weapon _startingWeapon;
    [SerializeField] Transform[] _barrel;
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
        currentWeapon = _startingWeapon;
        weaponLevel = 0;
        weaponLevelMax = _barrel.Length;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        Debug.Log(weaponLevel);
        _shakeMagnitude = currentWeapon.shakeMagnitude;
        //SpriteRenderer.sprite = currentWeapon.skin;
        _shakeRoughness = currentWeapon.shakeRoughness;
        _shakeFadeInTime = currentWeapon.shakeFadeInTime;
        _shakeFadeOutTime = currentWeapon.shakeFadeOutTime;
        _fireRate = currentWeapon.fireRate;
        _timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && _timer > _fireRate)
        {
            for (int i = 0; i < weaponLevel + 1; i++)
            {
                EZCameraShake.CameraShaker.Instance.ShakeOnce(_shakeMagnitude, _shakeRoughness, _shakeFadeInTime, _shakeFadeOutTime);
                GameObject bullet = BulletPooling.m_BulletInstance.GetBulletObject();
                if (bullet != null)
                {
                    bullet.transform.position = _barrel[i].position;
                    bullet.transform.rotation = _barrel[i].rotation;
                    bullet.SetActive(true);
                }
            }
            _timer = 0;
        }
    }
    public static void ChangeWeapon(Weapon weapon)
    {

        currentWeapon = weapon;
        GameObject.Find("BulletPooling").GetComponent<BulletPooling>().ChangeActiveBullet(currentWeapon.bulletName);
    }
}
