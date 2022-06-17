using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPooling : MonoBehaviour
{
    public static EnemiesPooling m_EnemyInstance;
    public List<GameObject> m_EnemiesPooled;
    public GameObject m_EnemiesPrefabs;
    [SerializeField] int m_amountToPool;


    void Awake()
    {
        m_EnemyInstance = this;
    }


    private void Start()
    {
        m_EnemiesPooled = new List<GameObject>();
        GameObject enemy;
        for (int i = 0; i < m_amountToPool; i++)
        {
            enemy = Instantiate(m_EnemiesPrefabs);
            enemy.SetActive(false);
            m_EnemiesPooled.Add(enemy);

        }
    }

    public GameObject GetEnemy(string enemyName)
    {
        for (int i = 0; i < m_amountToPool; i++)
        {
            if (!m_EnemiesPooled[i].activeInHierarchy)
            {
                for (int y = 0; y < m_EnemiesPooled[0].GetComponent<EnemyToSpawn>().m_enemiesGO.Length; y++)
                {
                    EnemyMovement enemy = m_EnemiesPooled[i].GetComponent<EnemyToSpawn>().m_enemiesGO[y].GetComponent<EnemyMovement>();
                    if ( enemy.enemyData.charName == enemyName)
                    {
                        enemy.gameObject.SetActive(true);
                        return m_EnemiesPooled[i];
                    }
                }
            }
        }
        return null;
    }
}
