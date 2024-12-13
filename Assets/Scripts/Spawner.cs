using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target _targetPrefab;

    private readonly int _poolCount = 5;
    private Pool<Enemy> _pool;
    private Target _target;

    private void Awake()
    {
        _pool = new Pool<Enemy>(_enemyPrefab, _poolCount);
        _target = Instantiate(_targetPrefab);
    }

    public void SpawnEnemys()
    {
        Enemy enemy = _pool.GetObject();
        enemy.Initialize(transform.position, _target);

        enemy.Died += OnDied;
    }

    private void OnDied(Enemy enemy)
    {
        _pool.ReleaseObject(enemy);
        enemy.Died -= OnDied;
    }
}