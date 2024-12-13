using System.Collections;
using UnityEngine;

public class SpawnerGenerator : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;

    private readonly float _spawnTimeDelay = 3f;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_spawnTimeDelay);
    }

    private void Start()
    {
        StartCoroutine(SpawningObjects());
    }

    private IEnumerator SpawningObjects()
    {
        while (enabled)
        {
            Spawner spawner = GetSpawner();

            spawner.SpawnEnemys();

            yield return _wait;
        }
    }

    private Spawner GetSpawner()
    {
        return _spawners[Random.Range(0, _spawners.Length)];
    }
}