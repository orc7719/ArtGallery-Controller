using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speed = 3f;

    [SerializeField] float sensitivityX = 10f;
    [SerializeField] float sensitivityY = 10f;
    float controllerDeadzone;

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

        transform.position += transform.forward * Input.GetAxis("Vertical")* speed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal")* speed * Time.deltaTime;
    }
}
