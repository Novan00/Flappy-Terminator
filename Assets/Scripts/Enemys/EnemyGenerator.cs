using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class EnemyGenerator : ObjectPool
{
    [SerializeField] private GameObject _tamplate;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private Coroutine _coroutine;

    private void Start()
    {
        Initialize(_tamplate);
        _coroutine = StartCoroutine(GenerateEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator GenerateEnemy()
    {
        while (true)
        {
            var delay = new WaitForSeconds(_secondsBetweenSpawn);

            if (TryGetObject(out GameObject enemy))
            { 
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);

                Vector3 spawnpoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                enemy.SetActive(true);
                enemy.transform.position = spawnpoint;

                DisableObjectAbroadScreen();
            }

            yield return delay;
        }
    }
}
