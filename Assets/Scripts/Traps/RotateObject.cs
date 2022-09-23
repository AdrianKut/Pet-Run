using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] Vector3 _vector3Eulers;

    void Update()
    {
        transform.Rotate(_vector3Eulers * _rotateSpeed * Time.deltaTime);
    }
}
