using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape1Mover : MonoBehaviour
{
    [SerializeField] private GridHandler gridHandler;
    private float _time = 0f;
    private void Start()
    {
        gridHandler = FindObjectOfType<GridHandler>();
    }
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 1f)
        {
            _time = 0;
            
            if (gridHandler.HasMovementEnded)
            {
                gridHandler.SetIsObjectDestroyed(true);
                DisplayGrid();
                Destroy(gameObject);
                return;
            }
            if (!gridHandler.HasMovementEnded)
            {
                MoveDown();    
            }
            EliminateFullRows();
        }
    }
    public void MoveDown()
    {

        if (!gridHandler.HasMovementEnded)
        {
            transform.Translate(0, 0, -10);
        }
        BroadcastMessage("OnMove", SendMessageOptions.DontRequireReceiver);
        BroadcastMessage("OnMoveDown", SendMessageOptions.DontRequireReceiver);
    }
    
    public void MoveRight()
    {
        if (!gridHandler.IsRightFilled)
        {
            transform.Translate(10, 0, 0);
        }
        BroadcastMessage("OnMove", SendMessageOptions.DontRequireReceiver);
        BroadcastMessage("OnMoveRight", SendMessageOptions.DontRequireReceiver);
    }

    public void MoveLeft()
    {
        if (!gridHandler.IsLeftFilled)
        {
            transform.Translate(-10, 0, 0);
        }
        BroadcastMessage("OnMove", SendMessageOptions.DontRequireReceiver);
        BroadcastMessage("OnMoveLeft", SendMessageOptions.DontRequireReceiver);
    }

    public void FastDrop()
    {
        MoveDown();
        _time = 0;
    }

    public void DisplayGrid()
    {
        String gridText = "";
        for (int i = 25; i >= 0; i--)
        {
            for (int j = 11; j >= 0; j--)
            {
                gridText = gridText + " " + gridHandler.GridArray[j, i];
            }
            gridText += "\n";
        }
        Debug.Log(gridText);
    }

    private void EliminateFullRows()
    {
        bool emptyFoundInRow = false;
        for (int i = 24; i >= 1; i--)
        {
            emptyFoundInRow = false;
            for (int j = 10; j >= 1; j--)
            {
                if (gridHandler.GridArray[j, i] != 2)
                {
                    emptyFoundInRow = true;
                }
            }
            if (emptyFoundInRow == false)
            {
                for (int j = 10; j >= 1; j--)
                {
                    gridHandler.GridArray[j, i] = 0;
                }
                
                for (int a = i; a <= 19; a++)
                {
                    for (int j = 10; j >= 1; j--)
                    {
                        if (a == i)
                        {
                            gridHandler.GridArray[j, a] = gridHandler.GridArray[j, a+1];
                        }
                        else
                        {
                            gridHandler.GridArray[j, a+1] = gridHandler.GridArray[j, a+2];
                        }
                    }
                }
            }
        }
    }
}
