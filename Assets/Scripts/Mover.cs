using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPoint;
    private Target _target;

    private void Update()
    {
        transform.LookAt(_targetPoint);
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);

        if (transform.position == _targetPoint)
        {
            _targetPoint = _target.GetRandomPosition();
        }
    }

    public void SetDirection(Vector3 point)
    {
        _targetPoint = point;
    }

    public void GetTarget(Target target)
    {
        _target = target;
    }
}