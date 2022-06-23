using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent m_UpgradeEvent;
    [SerializeField] int _enemiesToSpawn;
    [SerializeField] float _enemiesSpawnRate = 5;
    [SerializeField] int _enemyToSpawnIncrease = 20;
    [Tooltip("Drag and Drop the enemies you want to be spawned")] [SerializeField] Character[] _enemiesData;
    [SerializeField] private bool _SpawnNow = false;
    [SerializeField] private float _everyXsecIncreaseDifficulty = 120;
    public bool spawnEnemies = true;
    
    private float _timer = 0;
    private float _spawntimer = 0;
    private string _enemyNameToSpawn;
    private int _waveCount = 0;
    private int _counterCurrentEnemyNameIndex = 0;
    private void Awake()
    {
        _waveCount = 0;
        _enemyNameToSpawn = _enemiesData[0].charName;
    }

    void Update()
    {
        _spawntimer += Time.deltaTime;
        if (spawnEnemies)
        {
            if (_spawntimer > _enemiesSpawnRate || _SpawnNow)
                {
                    EnemiesSpawner.m_enemiesSpawnerInstance.SpawnEnemies(_enemiesToSpawn, _enemyNameToSpawn);
                    _spawntimer = 0;
                    _waveCount++;
                    _SpawnNow = false;
                }
        }
        _timer += Time.deltaTime;
        if (_timer > _everyXsecIncreaseDifficulty)
        {
            Time.timeScale = 0;
            m_UpgradeEvent.Invoke();
            _timer = 0;
        }

        
    }

    public void IncreaseEnemiesDifficulty()
    {
        Debug.Log("Increasing difficulty!");
        Debug.Log(_enemiesData.Length);
        _enemyNameToSpawn = _enemiesData[_counterCurrentEnemyNameIndex].charName;
        _enemiesToSpawn += _enemyToSpawnIncrease;
        if (_counterCurrentEnemyNameIndex < _enemiesData.Length-1) _counterCurrentEnemyNameIndex++;
    }
}
