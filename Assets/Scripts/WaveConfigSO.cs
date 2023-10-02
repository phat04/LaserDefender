using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float timeBetweenEnemySpawn = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumTimeSpawn = 0.2f;

    public Transform GetStartingWaypoint() 
    { 
        return pathPrefab.GetChild(0); 
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoinsList = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoinsList.Add(child);
        }
        return waypoinsList;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawn - spawnTimeVariance,
            timeBetweenEnemySpawn + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumTimeSpawn, float.MaxValue);
    }
}
