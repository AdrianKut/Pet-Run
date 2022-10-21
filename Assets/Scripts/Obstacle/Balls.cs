using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] private Transform[] _gameObjectBallsPosition;
    [SerializeField] private GameObject _gameObjectBallPrefab;
    [SerializeField] private float _forceSpeedBalls;
    [SerializeField] private bool _droped = false;
    [SerializeField] private float _endScaleValue = 4f;
    [SerializeField] private float _durationEndScale = 0.75f;

    void Update()
    {
        if (GameManager.Instance.GameState == GameState.Playing && _droped == false)
        {
            StartCoroutine(InstantiateAndDropTheBalls());
        }
    }

    public IEnumerator InstantiateAndDropTheBalls()
    {
        _droped = true;
        while (true)
        {
            for (int i = 0; i < _gameObjectBallsPosition.Length; i++)
            {
                var newBall = Instantiate(_gameObjectBallPrefab,
                    _gameObjectBallsPosition[i].position, _gameObjectBallsPosition[i].rotation);
                var rB = newBall.GetComponent<Rigidbody>();
                newBall.transform.DOScale(_endScaleValue, _durationEndScale);
                rB.constraints = RigidbodyConstraints.None;
                yield return new WaitForSeconds(0.5f);
                rB.AddForce(Vector3.down * _forceSpeedBalls, ForceMode.Force);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
