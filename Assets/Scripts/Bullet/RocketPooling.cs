using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPooling : MonoBehaviour
{
    public static RocketPooling m_rocketInstance;
    public List<GameObject> m_rocketPooled;
    public GameObject m_rocketPrefabs;
    [SerializeField] int m_amountToPool;


    void Awake()
    {
        m_rocketInstance = this;
    }


    private void Start()
    {
        m_rocketPooled = new List<GameObject>();
        GameObject bullet;
        for (int i = 0; i < m_amountToPool; i++)
        {
            bullet = Instantiate(m_rocketPrefabs);
            bullet.transform.SetParent(transform);
            bullet.SetActive(false);
            m_rocketPooled.Add(bullet);

        }
    }

    public GameObject GetBulletRocket()
    {
        for (int i = 0; i < m_amountToPool; i++)
        {
            if (!m_rocketPooled[i].activeInHierarchy)
            {
                return m_rocketPooled[i];
            }
        }
        return null;
    }
}
