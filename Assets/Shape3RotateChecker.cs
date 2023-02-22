using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape3RotateChecker : MonoBehaviour
{
    [SerializeField] private GridHandler _gridHandler;
    [SerializeField] private Shape1ChildRotater rotater;
    
    private void Start()
    {
        _gridHandler = FindObjectOfType<GridHandler>();
        rotater = GetComponent<Shape1ChildRotater>();
    }
    private void Update()
    {
        CheckRotateLeft();
        CheckRotateRight();
    }

    private void CheckRotateRight()
    {
        Vector3 pos = transform.position;

        if (rotater.TurnCounter == 0)
        {
            rotater.SetIsRightTurnAvailable(true);
        }

        if (rotater.TurnCounter == 1)
        {
            if (_gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10)+2, Mathf.RoundToInt((pos.z) / 10)] == 2 )
            {
                rotater.SetIsRightTurnAvailable(false);

            }
            else
            {
                rotater.SetIsRightTurnAvailable(true);

            }
        }

        if (rotater.TurnCounter == 2)
        {
            if (_gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10), Mathf.RoundToInt((pos.z-10) / 10)] == 2)
            {
                rotater.SetIsRightTurnAvailable(false);

            }
            else
            {
                rotater.SetIsRightTurnAvailable(true);

            }
        }

        if (rotater.TurnCounter == 3)
        {
            if (_gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10)-2, Mathf.RoundToInt((pos.z) / 10)] == 2 )
            {
                rotater.SetIsRightTurnAvailable(false);

            }
            else
            {
                rotater.SetIsRightTurnAvailable(true);

            }
        }

    }

    private void CheckRotateLeft()
    {
        Vector3 pos = transform.position;
        if (rotater.TurnCounter == 0)
        {
            if (_gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10) , Mathf.RoundToInt((pos.z) / 10)-1] == 2 )
            {
                rotater.SetIsLeftTurnAvailable(false);

            }
            else
            {
                rotater.SetIsLeftTurnAvailable(true);

            }
        }

        if (rotater.TurnCounter == 1)
        {
            if (_gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10)+2, Mathf.RoundToInt((pos.z) / 10) - 1] == 2)
            {
                rotater.SetIsLeftTurnAvailable(false);

            }
            else
            {
                rotater.SetIsLeftTurnAvailable(true);

            }
        }

        if (rotater.TurnCounter == 2)
        {
            if (_gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10), Mathf.RoundToInt((pos.z) / 10)-1] == 2 )
            {
                rotater.SetIsLeftTurnAvailable(false);

            }
            else
            {
                rotater.SetIsLeftTurnAvailable(true);

            }
        }

        if (rotater.TurnCounter == 3)
        {
            if (_gridHandler.GridArray[Mathf.RoundToInt(pos.x / 10)-2, Mathf.RoundToInt((pos.z) / 10)] == 2 )
            {
                rotater.SetIsLeftTurnAvailable(false);

            }
            else
            {
                rotater.SetIsLeftTurnAvailable(true);

            }
        }


    }
}