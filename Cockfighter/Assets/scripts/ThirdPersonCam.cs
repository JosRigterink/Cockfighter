using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform target, Player;
    float mouseX, mouseY;


    void Start()
    {
        
    }

    void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(target);

        Player.rotation = Quaternion.Euler(0, mouseX, 0);
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }

}
