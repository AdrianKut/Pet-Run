using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private Transform _destinationTransformPosition;
    [SerializeField] private float _speed;
    void Start()
    {
        
    }

    private void Update()
    {
        var a = (_destinationTransformPosition.transform.position - transform.position) * _speed * Time.deltaTime;
        transform.Translate(a);
    }
}
