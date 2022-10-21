using DG.Tweening;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectGlass;
    [SerializeField] private float _durationMoveX = 1f;
    [SerializeField] private float _offsetX;

    [SerializeField] private float _delayBetweenMoveX = 5f;
    private void Start()
    {
        StartCoroutine(MoveSpikeGlass());
    }

    public static GameObject a(GameObject gameObject)
    {
        return gameObject;
    }

    private IEnumerator MoveSpikeGlass()
    {
        var startXPos = _gameObjectGlass.transform.position.x;
        while (true)
        {
            _gameObjectGlass.transform.DOMoveX(startXPos - _offsetX, _durationMoveX);
            yield return new WaitForSeconds(_delayBetweenMoveX);
            _gameObjectGlass.transform.DOMoveX(startXPos, _durationMoveX);
            yield return new WaitForSeconds(_delayBetweenMoveX);
        }
    }
}
