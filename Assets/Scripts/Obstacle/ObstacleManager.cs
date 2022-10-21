using DG.Tweening;
using System.Collections;
using UnityEngine;
using static UnityEditor.Progress;

public class ObstacleManager : MonoBehaviour
{
    [Header("Cylinders")]
    [SerializeField] private GameObject[] _gameObjectCylinders;
    [SerializeField] private float _timeToDestroyCylinders = 1f;
    [SerializeField] private float _force = 2500f;

    void Update()
    {
        //cylinders1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DetonateCylinders();
        }

        //if (GameManager.Instance.GameState == GameState.Playing && _droped == false)
        //{
        //    StartCoroutine(_balls.InstantiateAndDropTheBalls());
        //} 
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
}

