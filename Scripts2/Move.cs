using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float mouseSensitivity = 2.5f;

    float xRotation = 0f;

    void Update()
    {
        if (Mouse.current == null || Keyboard.current == null)
            return;

        // Mouse look
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation =
            Quaternion.Euler(xRotation, transform.localEulerAngles.y + mouseX, 0f);

        // Movement (WASD)
        Vector3 move = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
            move += transform.forward;

        if (Keyboard.current.sKey.isPressed)
            move -= transform.forward;

        if (Keyboard.current.aKey.isPressed)
            move -= transform.right;

        if (Keyboard.current.dKey.isPressed)
            move += transform.right;

        if (Keyboard.current.eKey.isPressed)
            move += Vector3.up;

        if (Keyboard.current.qKey.isPressed)
            move += Vector3.down;

        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
