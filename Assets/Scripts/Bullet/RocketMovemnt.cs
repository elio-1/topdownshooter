using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovemnt : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    [SerializeField] Weapon rocketData;
    [SerializeField] Character playerData;
    float _randomRotation = 0;
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _rb2d.velocity = transform.right * rocketData.bulletSpeed * Time.deltaTime ;

        _randomRotation += Time.deltaTime * 50;
        transform.localEulerAngles = new Vector3(0, 0, _randomRotation);
    }
}
