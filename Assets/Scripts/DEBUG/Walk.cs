using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private Transform _destinationTransformPosition;
    [SerializeField] private float _forceSpeed;
    [SerializeField] private float _translateSpeed;

    private Rigidbody _rb;
    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.GameState == GameState.Playing)
        {
            //var a = (_destinationTransformPosition.transform.position - transform.position) * _translateSpeed * Time.fixedDeltaTime;
            //transform.Translate(a);
            //_rb.MovePosition(transform.position + _destinationTransformPosition.transform.position * _forceSpeed * Time.fixedDeltaTime);

            //transform.TransformDirection(_destinationTransformPosition.position * _forceSpeed * Time.deltaTime);

            _rb.velocity = Vector3.forward * _forceSpeed * Time.fixedDeltaTime;

            //_rb.AddForce(Vector3.forward * _forceSpeed, ForceMode.Acceleration);
            //_rb.velocity = (transform.forward * _destinationTransformPosition.transform.position.x + transform.right * mH).normalized * _speed * Time.deltaTime;

        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _destinationTransformPosition.position, _forceSpeed * Time.deltaTime);

    }

    public void SetDestinationPosition(Transform target)
    {
        _destinationTransformPosition = target;
    }
}
