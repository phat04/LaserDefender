using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigSOs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;

    WaveConfigSO currentWaveConfigSO;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWaveConfigSO;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigSOs)
            {
                currentWaveConfigSO = wave;
                for (int i = 0; i < currentWaveConfigSO.GetEnemyCount(); i++)
                {
                    Instantiate(currentWaveConfigSO.GetEnemyPrefab(0),
                        currentWaveConfigSO.GetStartingWaypoint().position, Quaternion.Euler(0, 0, 180), transform);
                    yield return new WaitForSeconds(currentWaveConfigSO.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }

        }
        while (isLooping);
    }
}
