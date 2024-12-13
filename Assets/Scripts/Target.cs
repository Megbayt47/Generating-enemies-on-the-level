using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Target : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private PlaceObject _placeObject;

    private Vector3 _position;
    private Vector3 _position2;
    private WaitForSeconds _wait;
    private readonly float _delay = 5f;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        transform.position = GetRandomPosition();
        _position2 = GetRandomPosition();
    }

    private void Start()
    {
        StartCoroutine(Shifting());
    }

    private IEnumerator Shifting()
    {
        while(enabled)
        {
            _position = GetRandomPosition();

            _mover.SetDirection(_position, _position2);

            yield return _wait;
        }
    }

    private Vector3 GetRandomPosition()
    {
        int negativeDevider = -2;
        int devider = 2;
        int indent = 5;

        float minRandomNumberX = _placeObject.transform.localScale.x / negativeDevider + indent;
        float maxRandomNumberX = _placeObject.transform.localScale.x / devider - indent;
        float minRandomNumberZ = _placeObject.transform.localScale.z / negativeDevider + indent;
        float maxRandomNumberZ = _placeObject.transform.localScale.z / devider - indent;

        float positionX = Random.Range(minRandomNumberX, maxRandomNumberX);
        float positionY = 1;
        float positionZ = Random.Range(minRandomNumberZ, maxRandomNumberZ);

        return new Vector3(positionX, positionY, positionZ);
    }
}