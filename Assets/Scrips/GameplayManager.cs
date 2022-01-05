using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private MatrixMap _matrixMap;
    public MatrixMap MatrixMap
    {
        get
        {
            if (!_matrixMap)
            {
                _matrixMap = FindObjectOfType<MatrixMap>();
            }
            return _matrixMap;
        }
    }
}
