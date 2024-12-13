using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Target : MonoBehaviour
{
    [SerializeField] private PlaceObject _placeObject;
    [SerializeField] private float _speed;

    private readonly float _minDistance = 0.1f;
    private Vector3 _position;
    private WaitForSeconds _wait;

    private void Awake()
    {
        transform.position = GetRandomPosition();
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

            yield return Moving();
        }
    }

    private IEnumerator Moving()
    {
        while (Vector3.Distance(transform.position, _position) >= _minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _position, _speed * Time.deltaTime);

            yield return null;
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