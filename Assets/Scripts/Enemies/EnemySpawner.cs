using JetBrains.Annotations;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _minimumSpawnTime = 0.5f;
    [SerializeField] private float _maxSpawnTime = 2f;

    public bool CanSpawn;

    private float _timeUntilSpawn;
    private const int MaxEnemies = 10;

    void Awake()
    {
        CanSpawn = false;
        SetTimeUntilSpawn();
    }

    void Update()
    {
        if (CanSpawn == true)
        {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0 && CountEnemiesInScene() < MaxEnemies)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
        }
       
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maxSpawnTime);
    }

    private int CountEnemiesInScene()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void SetCanSpawn(bool canSpawn)
    {
        CanSpawn = canSpawn;
       // Debug.Log($"Spawner {gameObject.name} CanSpawn set to {CanSpawn}");
    }

}
