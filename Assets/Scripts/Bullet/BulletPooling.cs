using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    public static BulletPooling m_BulletInstance;
    public List<GameObject> m_bulletPooled;
    public GameObject m_bulletPrefabs;
    [SerializeField] int m_amountToPool;

   
        void Awake()
    {
        m_BulletInstance = this;
    }


    private void Start()
    {
        m_bulletPooled = new List<GameObject>();
        GameObject bullet;
        for (int i = 0; i < m_amountToPool; i++)
        {
            bullet = Instantiate(m_bulletPrefabs);
            bullet.SetActive(false);
            m_bulletPooled.Add(bullet);
     
        }
    }

    public GameObject GetBulletObject()
    {
        for (int i = 0; i < m_amountToPool; i++)
        {
            if (!m_bulletPooled[i].activeInHierarchy)
            {
                return m_bulletPooled[i];
            }
        }
        return null;
    }
    public void ChangeActiveBullet(string newBullet)
    {
        Debug.Log("changeactivebullet");
        BulletMovement bullet;
        for (int i = 0; i < m_amountToPool; i++)
        {
            bullet = m_bulletPooled[i].GetComponent<BulletMovement>();
            for (int y = 0; y < m_bulletPooled[0].GetComponent<BulletMovement>().m_bulletsGO.Length; y++)
            {
                if (bullet.m_bulletsGO[y].name == newBullet)
                {
                    bullet.m_bulletsGO[y].SetActive(true);
                    Debug.Log("active" + bullet.m_bulletsGO[y].name);
                }
                else
                {
                    bullet.m_bulletsGO[y].SetActive(false);
                    Debug.Log("desactive" + bullet.m_bulletsGO[y].name);
                }
            }

        }
    }
}
