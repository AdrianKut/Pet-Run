using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    void Update()
    {
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
    }
}
