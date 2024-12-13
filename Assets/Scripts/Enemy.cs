using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshMover _mover;

    private Renderer _renderer;
    private Rigidbody _rigidbody;
    private Target _target;

    public event Action<Enemy> Deathed;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Target target))
        {
            if (target == _target)
            {
                Deathed?.Invoke(this);
            }
        }
    }

    public void Initialize(Vector3 position, Target target)
    {
        transform.position = position;
        _mover.SetTarget(target);
        _target = target;
    }
}