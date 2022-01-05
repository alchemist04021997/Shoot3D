using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Character, IMoveFast, IMoveNormal
{
    public List<Transform> points = new List<Transform>();
    //MatrixMap matrixMap;
    Vector3 lookForward;
    public void NormalMove(Vector3 speed)
    {
        if (speed == Vector3.zero)
        {
            return;
        }
        transform.localPosition += speed;
        transform.localRotation = Quaternion.LookRotation(speed);
    }
    //private void Awake()
    //{
    //    matrixMap = GameplayManager.Instance.MatrixMap;
    //}
    //private void Start()
    //{
    //    transform.position = matrixMap.matrixMap[0, 0];
    //}
    private void FixedUpdate()
    {
        //NormalMove((points[0].position - transform.position).normalized * 0.1f);
        //if ((points[0].position - transform.position).magnitude < 0.5f)
        //{
        //    points.Remove(points[0]);
        //}
        lookForward = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            lookForward += Vector3.forward;
        }
        if(Input.GetKey(KeyCode.S))
        {
            lookForward += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            lookForward += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            lookForward += Vector3.left;
        }

        NormalMove(lookForward.normalized * 0.1f);
    }
}
