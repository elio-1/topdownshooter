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
    [SerializeField] float _rocketCD = 4;

    float _shakeMagnitude;
    float _shakeRoughness;
    float _shakeFadeInTime;
    float _shakeFadeOutTime;
    float _timer = 0 ;
    float _timer2 = 0;
    float _fireRate;
    float _specialFireRate;


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

        _shakeMagnitude = currentWeapon.shakeMagnitude;
        //SpriteRenderer.sprite = currentWeapon.skin;
        _shakeRoughness = currentWeapon.shakeRoughness;
        _shakeFadeInTime = currentWeapon.shakeFadeInTime;
        _shakeFadeOutTime = currentWeapon.shakeFadeOutTime;
        _fireRate = currentWeapon.fireRate;
        _timer += Time.deltaTime;
        _timer2 += Time.deltaTime;

        switch (PlayerHealth.currentState)
        {
            case PlayerState.Alive:
                if (Input.GetMouseButton(0) && _timer > _fireRate && !PauseUnpause.PauseUnpauseInstance.IsPause())
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
                if (Input.GetMouseButton(1) && _timer2 > _rocketCD && !PauseUnpause.PauseUnpauseInstance.IsPause())
                {
                    for (int i = 0; i < 3; i++)
                    {
                        EZCameraShake.CameraShaker.Instance.ShakeOnce(_shakeMagnitude, _shakeRoughness * 1.4f, _shakeFadeInTime, _shakeFadeOutTime);
                        GameObject rocket = RocketPooling.m_rocketInstance.GetBulletRocket();
                        if (rocket != null)
                        {
                            rocket.transform.position = _barrel[i].position;
                            rocket.transform.rotation = _barrel[i].rotation;
                            rocket.SetActive(true);
                        }
                    }
                    _timer2 = 0;
                }
                break;
            case PlayerState.Dead:
                break;
            default:
                break;
        }
        

        
    }
    public static void ChangeWeapon(Weapon weapon)
    {

        currentWeapon = weapon;
        GameObject.Find("BulletPooling").GetComponent<BulletPooling>().ChangeActiveBullet(currentWeapon.bulletName);
    }
}
