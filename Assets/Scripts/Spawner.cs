using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _poolCount;
    [SerializeField] private PointSpawnObject[] _startPoints;

    private Pool<Enemy> _pool;
    private WaitForSeconds _wait;
    private float _spawnTimeDelay = 2f;
    private Vector3 _position;
    private Vector3 _direction;

    private void Awake()
    {
        _pool = new Pool<Enemy>(_enemy, _poolCount);
        _wait = new WaitForSeconds(_spawnTimeDelay);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemys());
    }

    private IEnumerator SpawnEnemys()
    {
        while (enabled)
        {
            PointSpawnObject point = GetStartPoint();

            _position = point.transform.position;
            _direction = point.GetRandomDirection();

            Enemy enemy = _pool.GetObject();
            enemy.Initialize(_position, _direction);
            enemy.Deathed += OnDeath;

            yield return _wait;
        }
    }

    private void OnDeath(Enemy enemy)
    {
        _pool.ReleaseObject(enemy);
        enemy.Deathed -= OnDeath;
    }

    private PointSpawnObject GetStartPoint()
    {
        return _startPoints[Random.Range(0, _startPoints.Length)];
    }
}