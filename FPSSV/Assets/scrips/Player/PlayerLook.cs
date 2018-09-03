using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    [HideInInspector]
    public float mouseX;
    [HideInInspector]
    public float mouseY;

    public float mouseSensitivity;
    public bool invertMouse;
    public Transform PlayerBody;
    
    
    // Use this for initialization

    float xClam = 0.0f;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        invertMouse = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        RotateCamera();

    }

    void RotateCamera()
    {

        float rotMouseX = mouseX * mouseSensitivity;
        float rotMouseY = mouseY * mouseSensitivity;

        xClam -= rotMouseY;
        Vector3 targetRotCam = this.transform.rotation.eulerAngles;
        Vector3 targetRotPlay = PlayerBody.rotation.eulerAngles;



        if (!invertMouse)
        {
            targetRotCam.x += rotMouseY;

        }
        else
        {
            targetRotCam.x -= rotMouseY;
            //  xClam += rotMouseY;
        }

        targetRotCam.z = 0;

        targetRotPlay.y += rotMouseX;

        if (xClam > 90)
        {
            xClam = 90;
            targetRotCam.x = -90;
        }
        else if (xClam < -90)
        {
            xClam = -90;
            targetRotCam.x = -270;
        }
        transform.rotation = Quaternion.Euler(targetRotCam);
        PlayerBody.rotation = Quaternion.Euler(targetRotPlay);
    }
}
