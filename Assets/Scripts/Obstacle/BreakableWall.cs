using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectParticleEffect;
    [SerializeField] private GameObject _gameObjectWall;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Player>() || collider.gameObject.GetComponent<Walk>())
        {
            _gameObjectParticleEffect.SetActive(true);
            Destroy(_gameObjectWall);
        }
    }
}
