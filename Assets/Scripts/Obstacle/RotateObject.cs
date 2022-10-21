using DG.Tweening;
using System.Collections;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [Header("DoTweenRotation")]
    [SerializeField] private Vector3 _vector3Value;
    [SerializeField] private bool _doRotate = false;
    [SerializeField] private float _rotateInterval = 0.5f;
    [SerializeField] private Ease _ease;

    [Header("EulerRotation")]
    [SerializeField] private Vector3 _vector3Eulers;
    [SerializeField] private float _rotateSpeed;
    private void Start()
    {
        if (_doRotate)
            StartCoroutine(A());
    }

    private IEnumerator A()
    {
        while (true)
        {
            transform.DORotate(_vector3Value, _rotateInterval).SetEase(_ease);
            yield return new WaitForSeconds(_rotateInterval);
            transform.DORotate(-_vector3Value, _rotateInterval).SetEase(_ease);
            yield return new WaitForSeconds(_rotateInterval);
        }
    }

    private void Update()
    {
        transform.Rotate(_vector3Eulers * _rotateSpeed * Time.deltaTime);
    }
}
