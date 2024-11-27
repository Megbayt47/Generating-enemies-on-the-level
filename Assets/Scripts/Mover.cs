using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    private Vector3 _movementDirection;

    private void Update()
    {
        transform.Translate(_movementDirection * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _movementDirection = direction;
    }
}