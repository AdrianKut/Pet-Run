using UnityEngine;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _destinationTransformPosition;
    [SerializeField] private TextMeshPro _playerNickname;
    [SerializeField] private float _speed;

    public NavMeshAgent Agent { get; private set; }

    private void Awake()
    {
        Agent = this.gameObject.GetComponent<NavMeshAgent>();
        Agent.isStopped = true;
    }

    private void LateUpdate()
    {
        RotateNicknameToCamera();
       // CalculateDistanceToDistancePosition();
    }

    public void SetDestinationPosition(Transform target)
    {
        _destinationTransformPosition = target;
        Agent.SetDestination(_destinationTransformPosition.position);
    }

    public float GetDistanceToDestiantionPosition()
    {
        return (transform.position - _destinationTransformPosition.transform.position).sqrMagnitude;
    }

    private void RotateNicknameToCamera()
    {
        _playerNickname.transform.rotation = Camera.main.transform.rotation;
    }
}
