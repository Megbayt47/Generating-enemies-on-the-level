using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPoint;
    private Vector3 _newTargetPoint;
    private Target _target;

    private void Update()
    {
        transform.LookAt(_targetPoint);
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);

        if (transform.position == _targetPoint)
        {
            _newTargetPoint = _target.GetRandomPosition();
            _targetPoint = _newTargetPoint;
        }
    }

    public void SetDirection(Vector3 point, Target target)
    {
        _targetPoint = point;
        _target = target;
    }
}