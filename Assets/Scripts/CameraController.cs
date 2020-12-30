using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public float RotationSpeed = 5;

    public Transform Player;
    float mouseX;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CamControl();
    }

    private void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        
        transform.LookAt(Player);

        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
