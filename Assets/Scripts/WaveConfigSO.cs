using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]

public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float fltMoveSpeed = 5f;
    [SerializeField] float flTimeBetweenEnemySpawns = 1f;
    [SerializeField] float flSpawnTimeVariance = 0f;
    [SerializeField] float flMinimumSpawnTime = 0.2f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return fltMoveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(flTimeBetweenEnemySpawns - flSpawnTimeVariance,
                                        flTimeBetweenEnemySpawns + flSpawnTimeVariance);
        return Mathf.Clamp(spawnTime, flMinimumSpawnTime, float.MaxValue);
    }
}
