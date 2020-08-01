using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

//TODO: потом систему спавна надо будет доработать и усложнить, потому что будет не один вид врагов
public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    [SerializeField] private GameManager _gameManager;

    [Header("Waves")]
    [SerializeField] private Wave[] waves;

    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private float _countdown = 2f;

    [Header("Current Wave Count")]
    [SerializeField] private int _waveIndex = 0;

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (_waveIndex == waves.Length)
        {
            _gameManager.WinLevel();
            this.enabled = false;
        }

        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = _timeBetweenWaves;
            return;
        }

        _countdown -= Time.deltaTime;
    }

    
    private IEnumerator SpawnWave()
    {
        Wave wave = waves[_waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        _waveIndex++;
    }

    private void SpawnEnemy(GameObject enemyPref)
    {
        Instantiate(enemyPref, _spawnPoint.position, _spawnPoint.rotation);
    }
}
