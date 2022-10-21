using TMPro;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _destinationTransformPosition;
    [SerializeField] private TextMeshPro _playerNickname;

    public NavMeshAgent Agent { get; private set; }

    private void Awake()
    {
        Agent = this.gameObject.GetComponent<NavMeshAgent>();
        Agent.isStopped = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;

            Debug.Log("KLIKP");
            Agent.isStopped = true;
            Agent.ResetPath();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;

            Debug.Log("KLIKO");
            Agent.isStopped = false;
            Agent.updatePosition = _destinationTransformPosition;
            Agent.SetDestination(_destinationTransformPosition.position);
        }
    }

    //public void FixedUpdate()
    //{
    //    RaycastSurface();
    //}

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

    private void RaycastSurface()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,50f,1<<7))
        {
            Debug.DrawRay(transform.position, Vector3.down, Color.red);
            Debug.Log(hit.transform.name);
        }
    }
}
