using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixMap : MonoBehaviour
{
    [HideInInspector] public Vector3[,] matrixMap = new Vector3[40, 40];
    Vector3 firstPointPos = new Vector3(-100, 0, -100);
    public List<Transform> terain = new List<Transform>();
    private void Awake()
    {
        CreateMap();
    }
    private void Start()
    {
        for(int y = 0, x; y < matrixMap.GetLength(1); y++)
        {
            for (x = 0; x < matrixMap.GetLength(0); x++)
            {
                if (CheckHighZone(matrixMap[x, y]))
                {
                    matrixMap[x, y] += Vector3.up;
                }
                else
                {
                    //Debug.DrawLine(matrixMap[x, y], matrixMap[x, y] + Vector3.up*10, Color.red, 100);
                }
            }
        }
    }
    bool CheckHighZone(Vector3 position)
    {
        Vector3 firstPos;
        for (int x = 0; x < terain.Count; x++)
        {
            firstPos = 
                new Vector3(terain[x].position.x - 6,
                terain[x].position.y,
                terain[x].position.z - 6);
            if(position.x > firstPos.x&&
                position.x < firstPos.x + 18&&
                position.z > firstPos.z&&
                position.z < firstPos.z + 12)
            {
                return true;
            }
        }
        return false;
    }
    void CreateMap()
    {
        for (int y = 0, x; y < matrixMap.GetLength(1); y++)
        {
            for (x = 0; x < matrixMap.GetLength(0); x++)
            {
                matrixMap[x, y] = new Vector3(firstPointPos.x + x * 5, 0, firstPointPos.z + y * 5);
            }
        }
    }
}
