using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

}

public interface IMoveNormal
{
    public void NormalMove(Vector3 speed);
}
public interface IMoveFast
{

}
