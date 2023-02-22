using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape2MoveChecker : MonoBehaviour
{
    [SerializeField] private GridHandler gridHandler;
    [SerializeField] private int width = 2;

    private Vector3 _previousPos;
    private Shape1ChildRotater _rotator;

    private void Start()
    {
        _previousPos = transform.position;
        gridHandler = FindObjectOfType<GridHandler>();
        _rotator = GetComponentInChildren<Shape1ChildRotater>();

    }

    private void Update()
    {
        CheckMoveDown();
        CheckMoveLeft();
        CheckMoveRight();
    }

    private void CheckMoveDown()
    {
        Vector3 pos = transform.position;
        if (_rotator.TurnCounter == 0)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10), Mathf.RoundToInt((pos.z - 10) / 10)] == 2)
            {
                gridHandler.SetIsMovementEnded(true);
                Debug.Log("Movement Ended");
            }
        }
        
    }

    private void CheckMoveRight()
    {
        Vector3 pos = transform.position;
        if (_rotator.TurnCounter == 0)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) + width, Mathf.RoundToInt((pos.z) / 10)] == 2)
            {
                gridHandler.SetIsRightFilled(true);
            }
            else
            {
                gridHandler.SetIsRightFilled(false);
            }
        }
    }

    private void CheckMoveLeft()
    {
        Vector3 pos = transform.position;

        if (_rotator.TurnCounter == 0)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) -1, Mathf.RoundToInt((pos.z) / 10)] == 2)
            {
                gridHandler.SetIsLeftFilled(true);
            }
            else
            {
                gridHandler.SetIsLeftFilled(false);
            }
        }
    }
}