using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateCalculator : MonoBehaviour
{
    private Vector2 _coordinate;
    public Vector2 Coordinates => _coordinate;
    
    private int _firstIndex;
    public int FirstIndex => _firstIndex;
    
    private int _secondIndex;
    public int SecondIndex => _secondIndex;
    
    
    private void Awake()
    {
        Vector3 pos = transform.position;
        _coordinate.x = pos.x / 10;
        _coordinate.y = pos.z / 10;

        _firstIndex = Mathf.RoundToInt(_coordinate.x);
        _secondIndex = Mathf.RoundToInt(_coordinate.y);
        transform.name = $"{_firstIndex},{_secondIndex}";
    }
}
