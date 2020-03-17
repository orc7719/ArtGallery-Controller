using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speed = 3f;

    [SerializeField] float sensitivityX = 10f;
    [SerializeField] float sensitivityY = 10f;
    float controllerDeadzone = 0.25f;

    float rotationX = 0.0f;
    float rotationY = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 stickInput = new Vector2(Input.GetAxis("LookX"), Input.GetAxis("LookY"));
        if (stickInput.magnitude < controllerDeadzone)
            stickInput = Vector2.zero;
        else
            stickInput = stickInput.normalized * ((stickInput.magnitude - controllerDeadzone) / (1 - controllerDeadzone));

        rotationX += stickInput.x * sensitivityX * Time.deltaTime;
        rotationY += stickInput.y * sensitivityY * Time.deltaTime;

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        Vector2 stickInputMove = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        if (stickInputMove.magnitude < controllerDeadzone)
            stickInputMove = Vector2.zero;
        else
            stickInputMove = stickInputMove.normalized * ((stickInputMove.magnitude - controllerDeadzone) / (1 - controllerDeadzone));

        transform.position += transform.forward * stickInputMove.x* speed * Time.deltaTime;
        transform.position += transform.right * stickInputMove.y* speed * Time.deltaTime;
        transform.position += transform.up * Input.GetAxis("Ascend") * speed * Time.deltaTime;
    }
}
