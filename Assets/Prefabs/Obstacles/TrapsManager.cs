using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TrapsManager : MonoBehaviour
{
    [Header("Cylinders")]
    [SerializeField] private GameObject[] _gameObjectCylinders;
    [SerializeField] private float _timeToDestroyCylinders = 1f;
    [SerializeField] private float _force = 2500f;

    [Header("Spike")]
    [SerializeField] private GameObject _gameObjectGlass;
    [SerializeField] private float _durationMoveX = 1f;

    [Header("Balls")]
    [SerializeField] private GameObject _gameObjectBalls;

    void Update()
    {
        //cylinders1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DetonateCylinders();
        }

        //Spikes
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(MoveSpikeGlass());
        }
    }

    private void DetonateCylinders()
    {
        foreach (var cylinder in _gameObjectCylinders)
        {
            var rb = cylinder.transform.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * _force, ForceMode.Force);
            Destroy(cylinder, _timeToDestroyCylinders);
        }
    }

    private IEnumerator MoveSpikeGlass()
    {
        var startXPos = _gameObjectGlass.transform.position.x;
        _gameObjectGlass.transform.DOMoveX(startXPos - 9.4f, _durationMoveX);
        yield return new WaitForSeconds(5f);
        _gameObjectGlass.transform.DOMoveX(startXPos, _durationMoveX);
    }
}
