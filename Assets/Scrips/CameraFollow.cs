using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    Camera mainCam;
    Vector3 mousePos;
    Vector3 topDownCam, backCam, localTopDown, localBack, position;
    Quaternion topDownCamRot, backCamRot;
    bool isBackCam, isTopDownCam = true;
    [SerializeField] Button topDownCamBt, backCamBt;
    private void Awake()
    {
        mainCam = Camera.main;
        topDownCamBt.onClick.AddListener(ChangeTopDownCam);
        backCamBt.onClick.AddListener(ChangeBackCam);
    }
    private void Start()
    {
        topDownCam = mainCam.transform.position;
        localTopDown = topDownCam - transform.position;

        backCam = new Vector3(-0.35f, 3, -9);
        localBack = backCam - transform.position;

        topDownCamRot = Quaternion.Euler(61, 0, 0);
        backCamRot = Quaternion.Euler(6, 0.6f, 0);
    }
    private void Update()
    {
        if (isTopDownCam)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Input.mousePosition;
                mainCam.transform.position += new Vector3(Input.mousePosition.x - mousePos.x, 0, Input.mousePosition.y - mousePos.y) * 0.1f;
            }
            if (Input.GetMouseButton(0))
            {
                mainCam.transform.position += new Vector3(Input.mousePosition.x - mousePos.x, 0, Input.mousePosition.y - mousePos.y) * 0.1f;
                mousePos = Input.mousePosition;
            }
            else
            {
                position = Vector3.Lerp(mainCam.transform.position, transform.position + localTopDown, 0.1f);
                position.y = topDownCam.y;
                mainCam.transform.position = position;
            }
        }
        else if (isBackCam)
        {
            position = Vector3.Lerp(mainCam.transform.position, transform.position + localBack, 1f);
            position.y = localBack.y;
            mainCam.transform.position = position;
        }
    }
    void ChangeBackCam()
    {
        if (!isBackCam)
        {
            mainCam.transform.rotation = backCamRot;
            isBackCam = true;
            isTopDownCam = false;
        }
    }

    void ChangeTopDownCam()
    {
        if (!isTopDownCam)
        {
            mainCam.transform.rotation = topDownCamRot;
            isBackCam = false;
            isTopDownCam = true;
        }
    }
}
