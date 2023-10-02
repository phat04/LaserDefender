using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderScript : MonoBehaviour
{
    EnemySpawnerScript enemySpawnerScript;
    WaveConfigSO waveConfigSO;
    List<Transform> waypointsList;
    int waypointIndex = 0;

    void Awake()
    {
        enemySpawnerScript =  FindObjectOfType<EnemySpawnerScript>();
    }

    void Start()
    {
        waveConfigSO = enemySpawnerScript.GetCurrentWave();
        waypointsList = waveConfigSO.GetWayPoints();
        transform.position = waypointsList[waypointIndex].position;
    }

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (waypointIndex < waypointsList.Count)
        {
            Vector3 targetPosition = waypointsList[waypointIndex].position;
            float delta = waveConfigSO.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
