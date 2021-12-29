using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Character, IMoveFast, IMoveNormal
{
    public List<Transform> points = new List<Transform>();
    public void NormalMove(Vector3 speed)
    {
        transform.localPosition += speed;
        transform.localRotation = Quaternion.LookRotation(speed);
    }
    private void FixedUpdate()
    {
        NormalMove((points[0].position - transform.position).normalized * 0.1f);
        if((points[0].position - transform.position).magnitude < 0.5f)
        {
            points.Remove(points[0]);
        }
    }
}
