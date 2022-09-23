using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private Transform[] _transformsCorners;

    public float GetMinX()
    {
        return _transformsCorners[0].transform.position.x;
    }

    public float GetMaxX()
    {
        return _transformsCorners[1].transform.position.x;
    }

    public float GetMinZ()
    {
        return _transformsCorners[2].transform.position.z;
    }

    public float GetMaxZ()
    {
        return _transformsCorners[0].transform.position.z;
    }
}
