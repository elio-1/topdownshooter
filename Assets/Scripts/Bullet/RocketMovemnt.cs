using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovemnt : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    [SerializeField] Weapon rocketData;
    [SerializeField] Character playerData;
    [SerializeField] float _rotationMultiplier = 3;
    [SerializeField] float _fullRota = 100;
    [SerializeField] float _changeDirectionRota = -100;
    [SerializeField] float _zigzagRotation = 50;
    [SerializeField] float _zigzagRate = 0.2f;
    [SerializeField] float _changeDirectionRate = 0.5f;
    [SerializeField] float maxDistance = 20;

    private float _changeDirTimer = 0;
    private float _zigzagtimer;
    float _randomRotation = 0;
    bool _changeRotation = true;
    float _randomNumber = 0;
    Transform _player;
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {

        if (_changeRotation)
        {
            _randomNumber = GenerateRdmNumber(0, 5);
            _changeRotation = false;
        }
        else
        {
            _changeDirTimer += Time.deltaTime;
            if (_changeDirTimer> _changeDirectionRate)
            {
                _changeDirTimer = 0;
                _changeRotation = true;
            }
        }
        if (_randomNumber > 3)
        {
            _randomRotation = _fullRota;
        }
        else if (_randomNumber > 2)
        {
            _randomRotation = _changeDirectionRota;

        }
        else if (_randomNumber > 1)
        {
            _randomRotation = _changeDirectionRota;
        }
        else
        {
            
            _zigzagtimer += Time.deltaTime;
            if (_zigzagtimer> _zigzagRate)
            {
                _randomRotation = _zigzagRotation;
                _zigzagtimer = 0;
            }
            else
            {
                _randomRotation = -_zigzagRotation;

            }
        }
        if ((transform.position - _player.transform.position).magnitude > maxDistance)
        {
            gameObject.SetActive(false);
        }
    }
 
        
  
    void FixedUpdate()
    {
        _rb2d.velocity = transform.right * rocketData.bulletSpeed * Time.deltaTime ;
        float rotation = _randomRotation * Time.deltaTime;
        Quaternion desiredRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, rotation);
        //transform.localEulerAngles = new Vector3(0, 0, rotation );
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * _rotationMultiplier);
    }

    private float GenerateRdmNumber(float minInclusive, float maxExclusive)
    {
        float rdm;
        rdm = Random.Range(minInclusive, maxExclusive);
        return rdm;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().currentHealth -= (rocketData.damage + playerData.baseAttack);
            gameObject.SetActive(false);
        }
    }
}
