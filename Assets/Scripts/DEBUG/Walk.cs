using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;

public class Walk : MonoBehaviour
{
    [SerializeField] private Transform _destinationTransformPosition;
    [SerializeField] private float _forceSpeed;
    [SerializeField] private float _translateSpeed;

    [SerializeField] private Rigidbody _rb;
    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rb.AddForce(Vector3.forward * _forceSpeed, ForceMode.Acceleration);
        //_rb.velocity = (transform.forward * _destinationTransformPosition.transform.position.x + transform.right * mH).normalized * _speed * Time.deltaTime;

        var a = (_destinationTransformPosition.transform.position - transform.position) * _translateSpeed * Time.deltaTime;
        transform.Translate(a);

    }

    void moveCharacter(Vector3 direction)
    {
        Vector3 offset = new Vector3(direction.x * transform.position.x, direction.y * transform.position.y, direction.z * transform.position.z);
        _rb.MovePosition(transform.position + (offset * _forceSpeed * Time.deltaTime));
    }
}
