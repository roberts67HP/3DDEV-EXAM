using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    public Transform playerBody;

    public float mouseSensitivity = 400f;
    private float xRotation = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameManager.instance.OnGameLose += OnGameOver;
    }
    void OnDestroy () {
        GameManager.instance.OnGameLose -= OnGameOver;
    }
    void OnGameOver() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update() {
        if(GameManager.instance.CurrentState == GameState.Game) {
            MouseLook();
        }
    }
    private void MouseLook () {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
