using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Target _targetPrefabe;
    [SerializeField] private PointSpawnObject _point;

    private Pool<Enemy> _pool;
    private readonly int _poolCount = 5;
    private Vector3 _position;
    private Target _target;

    private void Awake()
    {
        _pool = new Pool<Enemy>(_enemy, _poolCount);
        _target = Instantiate(_targetPrefabe);
    }

    public void SpawnEnemys()
    {
        _position = _point.transform.position;

        Enemy enemy = _pool.GetObject();
        enemy.Initialize(_position, _target);

        enemy.Deathed += OnDeath;
    }


    private void OnDeath(Enemy enemy)
    {
        _pool.ReleaseObject(enemy);
        enemy.Deathed -= OnDeath;
    }
}