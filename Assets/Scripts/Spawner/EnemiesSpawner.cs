using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public static EnemiesSpawner m_enemiesSpawnerInstance;
    [SerializeField] Transform _player;
    
    
    
    private void Awake()
    {
        m_enemiesSpawnerInstance = this;
    }

    public void SpawnEnemies(int count, string name)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject enemies = EnemiesPooling.m_EnemyInstance.GetEnemy(name);
            if (enemies != null)
            {
                float seed = Random.Range(0, 5);
                Vector3 randomPos= _player.position;
                if (seed > 3)
                {
                    randomPos += new Vector3(Random.Range(10, 13), Random.Range(-8, 8), 0);
                }
                else if (seed > 2)
                {
                    randomPos += new Vector3(Random.Range(-10, -13), Random.Range(-8, 8), 0);

                }
                else if (seed > 1)
                {
                    randomPos += new Vector3(Random.Range(-10, 10), Random.Range(8, 11), 0);

                }
                else
                {
                    randomPos += new Vector3(Random.Range(-10, 10), Random.Range(-8, -11), 0);

                }
            enemies.transform.position = randomPos ;
            enemies.SetActive(true);
            }
        }
    }
    
}
