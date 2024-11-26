using UnityEngine;

public class PointSpawnObject : MonoBehaviour
{
    public Vector3 GetRandomDirection()
    {
        float directionX = 0, directionY = 0, directionZ = 0;

        int minRandomNumber = -1;
        int maxRandomNumber = 1;

        while (directionX == 0 && directionZ == 0)
        {
            directionX = Random.Range(minRandomNumber, maxRandomNumber + 1);
            directionZ = Random.Range(minRandomNumber, maxRandomNumber + 1);
        }

        return new Vector3(directionX, directionY, directionZ);
    }
}