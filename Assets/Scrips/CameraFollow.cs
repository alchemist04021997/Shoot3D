using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera mainCam;
    Vector3 mousePos;
    private void Awake()
    {
        mainCam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mousePos = Input.mousePosition;
            mainCam.transform.position += new Vector3(Input.mousePosition.x - mousePos.x, 0, Input.mousePosition.y - mousePos.y) * 0.1f;
        }
        if (Input.GetMouseButton(1))
        {
            mainCam.transform.position += new Vector3(Input.mousePosition.x - mousePos.x, 0, Input.mousePosition.y - mousePos.y) * 0.1f;
            mousePos = Input.mousePosition;
        }
    }
}
