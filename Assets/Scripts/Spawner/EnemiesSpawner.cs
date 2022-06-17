using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    bool var = true;
    [SerializeField] Transform _player;
     [SerializeField] float _radius = 20;
    private void Update()
    {
       
        if (var)
        {
            SpawnEnemies(10, "Enemy2");
            var = false;
        }
            
        
    }
    public void SpawnEnemies(int count, string name)
    {
        for (int i = 0; i < count; i++)
        {
        GameObject enemies = EnemiesPooling.m_EnemyInstance.GetEnemy(name);
            enemies.transform.position = _player.position + Random.onUnitSphere * _radius ;
            enemies.SetActive(true);
        }
    }
    
}
