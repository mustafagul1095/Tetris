using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChecker : MonoBehaviour
{
    private Cube[] cubes;
    private GridHandler gridHandler;

    private void Awake()
    {
        cubes = GetComponentsInChildren<Cube>();
    }

    private void Start()
    {
        gridHandler = FindObjectOfType<GridHandler>();
        
    }
    
    private void Update()
    {
        CheckMoveDown();
        CheckMoveLeft();
        CheckMoveRight();
    }
    
    private void CheckMoveDown()
    {
        foreach (var cube in cubes)
        {
            var pos = cube.transform.position;
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10), Mathf.RoundToInt((pos.z - 10) / 10)] == 2)
            {
                gridHandler.SetIsMovementEnded(true);
                Debug.Log("Movement Ended");
            }
        }

    }
    private void CheckMoveLeft()
    {
        foreach (var cube in cubes)
        {
            var pos = cube.transform.position;
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) - 1, Mathf.RoundToInt((pos.z) / 10)] == 2)
            {
                gridHandler.SetIsLeftFilled(true);
                break;
            }

            gridHandler.SetIsLeftFilled(false);
        }

    }
    
    private void CheckMoveRight()
    {
        foreach (var cube in cubes)
        {
            var pos = cube.transform.position;
            if (gridHandler.GridArray[Grid.ToGrid(pos.x)+1, Grid.ToGrid(pos.z)] == 2)
            {
                gridHandler.SetIsRightFilled(true);
                break;
            }

            gridHandler.SetIsRightFilled(false);
        }

    }
}
