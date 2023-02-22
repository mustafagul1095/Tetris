using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape4MoveChecker : MonoBehaviour
{
    [SerializeField] private GridHandler gridHandler;
    [SerializeField] private int width = 3;

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
            if (gridHandler.GridArray[Grid.ToGrid(pos.x), Grid.ToGrid(pos.y)-1] == 2)
            {
                gridHandler.SetIsMovementEnded(true);
                Debug.Log("Movement Ended");
            }
        }

        if (_rotator.TurnCounter == 1)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt((pos.x-5) / 10), Mathf.RoundToInt((pos.z - 10) / 10)] == 2 ||
                gridHandler.GridArray[Mathf.RoundToInt((pos.x+5) / 10), Mathf.RoundToInt((pos.z + 5) / 10)] == 2 ||
                gridHandler.GridArray[Mathf.RoundToInt((pos.x+5) / 10), Mathf.RoundToInt((pos.z + 10) / 10)] == 2)
            {
                gridHandler.SetIsMovementEnded(true);
                Debug.Log("Movement Ended");
            }
        }

        if (_rotator.TurnCounter == 2)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt((pos.x+6) / 10), Mathf.RoundToInt((pos.z ) / 10)] == 2 ||
                gridHandler.GridArray[Mathf.RoundToInt((pos.x) / 10), Mathf.RoundToInt((pos.z +10) / 10)] == 2 ||
                gridHandler.GridArray[Mathf.RoundToInt((pos.x-6) / 10), Mathf.RoundToInt((pos.z +10) / 10)] == 2)
            {
                gridHandler.SetIsMovementEnded(true);
                Debug.Log("Movement Ended");
            }
        }

        if (_rotator.TurnCounter == 3)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt((pos.x) / 10), Mathf.RoundToInt((pos.z - 10) / 10)] == 2)
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
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) + width-1, Mathf.RoundToInt((pos.z) / 10)] == 2)
            {
                gridHandler.SetIsRightFilled(true);
            }
            else
            {
                gridHandler.SetIsRightFilled(false);
            }
        }

        if (_rotator.TurnCounter == 1)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) + width -2, Mathf.RoundToInt((pos.z) / 10)] == 2)
            {
                gridHandler.SetIsRightFilled(true);
            }
            else
            {
                gridHandler.SetIsRightFilled(false);
            }
        }

        if (_rotator.TurnCounter == 2)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) + width-1, Mathf.RoundToInt((pos.z) / 10)] == 2)
            {
                gridHandler.SetIsRightFilled(true);
            }
            else
            {
                gridHandler.SetIsRightFilled(false);
            }
        }

        if (_rotator.TurnCounter == 3)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) + width -1, Mathf.RoundToInt((pos.z) / 10)] == 2)
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
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) - width +1, Mathf.RoundToInt((pos.z) / 10)] == 2)
            {
                gridHandler.SetIsLeftFilled(true);
            }
            else
            {
                gridHandler.SetIsLeftFilled(false);
            }
        }

        if (_rotator.TurnCounter == 1)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) - width +1, Mathf.RoundToInt((pos.z) / 10)] == 2)
            {
                gridHandler.SetIsLeftFilled(true);
            }
            else
            {
                gridHandler.SetIsLeftFilled(false);
            }
        }

        if (_rotator.TurnCounter == 2)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) - width+1, Mathf.RoundToInt((pos.z) / 10)] == 2)
            {
                gridHandler.SetIsLeftFilled(true);
            }
            else
            {
                gridHandler.SetIsLeftFilled(false);
            }
        }

        if (_rotator.TurnCounter == 3)
        {
            if (gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) - width +2, Mathf.RoundToInt((pos.z) / 10)] == 2)
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