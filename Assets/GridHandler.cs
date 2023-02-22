using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class GridHandler : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject shape1Prefab;
    [SerializeField] private GameObject shape2Prefab;
    [SerializeField] private GameObject shape3Prefab;
    [SerializeField] private GameObject shape4Prefab;
    [SerializeField] private GameObject shape5Prefab;
    [SerializeField] private GameObject shape6Prefab;
    [SerializeField] private GameObject shape7Prefab;
    
    private int[,] _gridArray = new int[12, 26];
    public int[,] GridArray => _gridArray;

    private GameObject[] prefabArray ;

    private CoordinateCalculator coordinateCalculator;
    private float _time = 0f;
    private GameObject shape;
    Vector3 startPoint = new Vector3();
    private bool _hasMovementEnded;
    public bool HasMovementEnded => _hasMovementEnded;
    
    private bool _isObjectDestroyed;
    public bool IsObjectDestroyed => _isObjectDestroyed;
    
    private bool _isRightFilled;
    public bool IsRightFilled => _isRightFilled;
    
    private bool _isLeftFilled;
    public bool IsLeftFilled => _isLeftFilled;
    private GameObject cube;
    
    
    private void Start()
    {
        prefabArray = new[] { shape1Prefab, shape2Prefab, shape3Prefab, shape4Prefab, shape5Prefab, shape6Prefab, shape7Prefab };
        startPoint.x = 50;
        startPoint.y = 0;
        startPoint.z = 190;
        InstantiateGameObject();
        coordinateCalculator = cubePrefab.GetComponent<CoordinateCalculator>();
        FillWalls();
        
    }

    private void Update()
    {
        EnableFullGrids();
        if (_isObjectDestroyed)
        {
            _isObjectDestroyed = false;
            _hasMovementEnded = false;
            _isLeftFilled = false;
            _isRightFilled = false;
            InstantiateGameObject();
        }
    }

    public void SetIsMovementEnded(bool isEnded)
    {
        _hasMovementEnded = isEnded;
    }
    
    public void SetIsObjectDestroyed(bool isDestroyed)
    {
        _isObjectDestroyed = isDestroyed;
    }
    public void SetIsRightFilled(bool isFilled)
    {
        _isRightFilled = isFilled;
    }
    public void SetIsLeftFilled(bool isFilled)
    {
        _isLeftFilled = isFilled;
    }
    public void AddToGridArray(int x, int y)
    {
        _gridArray[x,y] = 1;
        
    }
    public void RemoveFromGridArray(int x, int y)
    {
        _gridArray[x,y] = 0;
    }

    private void InstantiateGameObject()
    {
        int i = Random.Range(0,prefabArray.Length);
        shape = Instantiate(prefabArray[i], startPoint, Quaternion.identity, gameObject.transform);
        BroadcastMessage("OnGameObjectInstantiated", SendMessageOptions.DontRequireReceiver);
    }

    private void FillWalls()
    {
        for (int i = 25; i >= 0; i--)
        {
            for (int j = 11; j >= 0; j--)
            {
                if (i is 0 or 25 || j is 0 or 11)
                {
                    _gridArray[j, i] = 2;
                }
            }
        }
    }

    private void EnableFullGrids()
    {
        for (int i = 20; i >= 0; i--)
        {
            for (int j = 11; j >= 0; j--)
            {
                if (_gridArray[j, i] == 2)
                {
                    String _name = $"{j},{i}";
                    GameObject cube =GameObject.Find(_name);
                    cube.GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    String _name = $"{j},{i}";
                    GameObject cube =GameObject.Find(_name);
                    cube.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }
}
