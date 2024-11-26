using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    public Vector3 MovementDirection { get; private set; }

    private void Update()
    {
        transform.Translate(MovementDirection * _speed * Time.deltaTime);
    }

    public void GetDirection(Vector3 direction)
    {
        MovementDirection = direction;
    }
}