using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float _forceJump;
    [SerializeField] private float _startSpeedValue;
    private float _speed;

    [SerializeField] private float _mouseSensitivityX = 5f;
    [SerializeField] private float _mouseSensitivityY = 5f;
    private float rotY = 0.0f;

    private bool isEnabledCursor = true;

    void Update()
    {
        CameraMovement();
        Sprint();
        JumpAndCrouch();

        HideOrShowCursor();
    }

    private void HideOrShowCursor()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isEnabledCursor = !isEnabledCursor;
            Cursor.visible = isEnabledCursor;
        }
    }

    private void CameraMovement()
    {
            float moveHorizontal = Input.GetAxis("Horizontal") * _speed;
            float moveVertical = Input.GetAxis("Vertical") * _speed;

            transform.Translate(Vector3.forward * moveVertical * Time.deltaTime);
            transform.Translate(Vector3.right * moveHorizontal * Time.deltaTime);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            float rotX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _mouseSensitivityX;
            rotY += Input.GetAxis("Mouse Y") * _mouseSensitivityY;
            rotY = Mathf.Clamp(rotY, -90f, 90f);
            transform.localEulerAngles = new Vector3(-rotY, rotX, 0.0f);
        }
    }

    private void JumpAndCrouch()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * _forceJump * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * _forceJump * Time.deltaTime);
        }
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _startSpeedValue * 2;
        }
        else
        {
            _speed = _startSpeedValue;
        }
    }
}
