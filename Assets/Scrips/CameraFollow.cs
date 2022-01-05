using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera mainCam;
    Vector3 mousePos;
    Vector3 localPosition, position, rootCameraPosition;
    Character character;
    private void Awake()
    {
        mainCam = Camera.main;
        character = FindObjectOfType<Character>();
    }
    private void Start()
    {
        rootCameraPosition = mainCam.transform.position;
        localPosition = rootCameraPosition - transform.position;
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
        position = Vector3.Lerp(mainCam.transform.position, transform.position + rootCameraPosition, 0.1f);
        position.y = rootCameraPosition.y;
        mainCam.transform.position = position;
    }
}
