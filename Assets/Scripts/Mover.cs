using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPoint;
    private Vector3 _targetPoint2;

    private void Update()
    {
        if (transform.position == _targetPoint)
        {
            _targetPoint = _targetPoint2;
        }

        transform.LookAt(_targetPoint);
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 point, Vector3 point2)
    {
        _targetPoint = point;
        _targetPoint2 = point2;
    }
}