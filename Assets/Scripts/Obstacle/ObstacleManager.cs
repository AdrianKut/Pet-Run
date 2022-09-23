using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("Cylinders")]
    [SerializeField] private GameObject[] _gameObjectCylinders;
    [SerializeField] private float _timeToDestroyCylinders = 1f;
    [SerializeField] private float _force = 2500f;

    [Header("Spike")]
    [SerializeField] private GameObject _gameObjectGlass;
    [SerializeField] private float _durationMoveX = 1f;

    [Header("Balls")]
    [SerializeField] private GameObject[] _gameObjectBalls;
    [SerializeField] private float _forceSpeedBalls;
    [SerializeField] private bool _droped = false;

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

        if (GameManager.Instance.GameState == GameState.Playing && _droped == false)
        {
            StartCoroutine(DropTheBalls());
        }
    }

    private IEnumerator DropTheBalls()
    {
        _droped = true;
        foreach (var item in _gameObjectBalls)
        {
            var rb = item.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.down * _forceSpeedBalls, ForceMode.Force);
            yield return new WaitForSeconds(1f);
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

