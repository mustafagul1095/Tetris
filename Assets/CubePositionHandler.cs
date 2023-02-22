using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePositionHandler : MonoBehaviour
{
    [SerializeField] private GridHandler grid;
    [SerializeField] private CoordinateCalculator coordinateCalculator;

    private float _time = 0f;
    private Vector3 _previousPos;
    
    private void Start()
    {
        grid = FindObjectOfType<GridHandler>();
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        if (grid.HasMovementEnded)
        {
            grid.GridArray[Mathf.RoundToInt(pos.x / 10), Mathf.RoundToInt(pos.z / 10)] = 2;
        }
    }

    private void OnMove()
    {
        Vector3 pos = transform.position;
        grid.RemoveFromGridArray(Mathf.RoundToInt(_previousPos.x/10),Mathf.RoundToInt(_previousPos.z/10));
        grid.AddToGridArray(Mathf.RoundToInt(pos.x/10),Mathf.RoundToInt(pos.z/10));
        _previousPos = pos;
        grid.SetIsMovementEnded(false);
        
    }
    
    // private void CheckMoveDown()
    // {
    //     Vector3 pos = transform.position;
    //     if (grid.GridArray[Mathf.RoundToInt(pos.x / 10), Mathf.RoundToInt((pos.z-10) / 10)] == 2)
    //     {
    //         grid.SetIsMovementEnded(true);
    //         Debug.Log("Movement Ended");
    //     }
    // }
    //
    // private void CheckMoveRight()
    // {
    //     Vector3 pos = transform.position;
    //     if (grid.GridArray[Mathf.RoundToInt(pos.x / 10)+1, Mathf.RoundToInt((pos.z) / 10)] == 2)
    //     {
    //         grid.SetIsRightFilled(true);
    //         Debug.Log("right is filled");
    //     }
    //     else
    //     {
    //         grid.SetIsRightFilled(false);
    //     }
    // }
    //
    // private void CheckMoveLeft()
    // {
    //     Vector3 pos = transform.position;
    //     if (grid.GridArray[Mathf.RoundToInt(pos.x / 10)-1, Mathf.RoundToInt((pos.z) / 10)] == 2)
    //     {
    //         grid.SetIsLeftFilled(true);
    //         Debug.Log("Left is filled");
    //     }
    //     else
    //     {
    //         grid.SetIsLeftFilled(false);
    //     }
    // }
    
    // private void Update()
    // {
    //     _time += Time.deltaTime;
    //     if (_time >= 1f)
    //     {
    //         _time = 0;
    //         MoveDown();
    //     }
    //
    // }

    // public void MoveDown()
    // {
    //     Vector3 pos = transform.position;
    //     grid.RemoveFromGridArray(Mathf.RoundToInt(pos.x/10),Mathf.RoundToInt(pos.z/10));
    //     pos.z -= 10;
    //     transform.position = pos;
    //     grid.AddToGridArray(Mathf.RoundToInt(pos.x/10),Mathf.RoundToInt(pos.z/10));
    //     
    // }
    //
    // public void MoveRight()
    // {
    //     Vector3 pos = transform.position;
    //     grid.RemoveFromGridArray(Mathf.RoundToInt(pos.x/10),Mathf.RoundToInt(pos.z/10));
    //     pos.x += 10;
    //     transform.position = pos;
    //     grid.AddToGridArray(Mathf.RoundToInt(pos.x/10),Mathf.RoundToInt(pos.z/10));
    // }
    //
    // public void MoveLeft()
    // {
    //     Vector3 pos = transform.position;
    //     grid.RemoveFromGridArray(Mathf.RoundToInt(pos.x/10),Mathf.RoundToInt(pos.z/10));
    //     pos.x -= 10;
    //     transform.position = pos;
    //     grid.AddToGridArray(Mathf.RoundToInt(pos.x/10),Mathf.RoundToInt(pos.z/10));
    // }


}
