using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    public event Action<Enemy> Deathed;

    private Renderer _renderer;
    private Rigidbody _rigidbody;
    private bool _isTouch;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        _mover.GetDirection(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Trigger trigger))
        {
            Deathed?.Invoke(this);
        }
    }
}