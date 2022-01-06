using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Character, IMoveFast, IMoveNormal
{
    public List<Transform> points = new List<Transform>();
    //MatrixMap matrixMap;
    Vector3 lookForward;
    float speed;
    Animator anim;
    Quaternion target;
    public void NormalMove(Vector3 speed)
    {
        if (speed == Vector3.zero)
        {
            return;
        }
        transform.localPosition += speed;
        target = Quaternion.LookRotation(speed);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, target, 15);
    }
    private void Awake()
    {
        //matrixMap = GameplayManager.Instance.MatrixMap;
        anim = GetComponent<Animator>();
    }
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
        anim.SetFloat("speed", speed);
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.1f;
        }
        else
        {
            speed = 0.01f;
        }
        NormalMove(lookForward.normalized * speed);
    }
}
