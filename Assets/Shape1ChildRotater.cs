using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape1ChildRotater : MonoBehaviour
{

    [SerializeField] private GridHandler _gridHandler;
    private bool _isRightRotationAvailable;
    private bool _isLeftRotationAvailable;
    private int _turnCounter = 0;
    public int TurnCounter => _turnCounter;
    
    private void Start()
    {
        _gridHandler = FindObjectOfType<GridHandler>();
        
    }
    
    public void SetIsRightTurnAvailable(bool val)
    {
        _isRightRotationAvailable = val;
    }
    
    public void SetIsLeftTurnAvailable(bool val)
    {
        _isLeftRotationAvailable = val;
    }
    
    public void IncrementTurnCounter()
    {
        _turnCounter++;
        if (_turnCounter == 4)
        {
            _turnCounter = 0;
        }
    }
    public void DecrementTurnCounter()
    {
        _turnCounter--;
        if (_turnCounter == -1)
        {
            _turnCounter = 3;
        }
    }
    
    public void RotateRight()
    {
        if (_isRightRotationAvailable)
        {

            transform.RotateAround(transform.position+Vector3.up*20, Vector3.up, 90);
            transform.Translate(-10,0,-10);
            BroadcastMessage("OnMove", SendMessageOptions.DontRequireReceiver);
            IncrementTurnCounter();
            
        }
    }
    
    public void RotateLeft()
    {
        if (_isLeftRotationAvailable)
        {
            transform.RotateAround(transform.position, Vector3.up, -90);
            transform.Translate(10,0,-10);
            BroadcastMessage("OnMove", SendMessageOptions.DontRequireReceiver);
            DecrementTurnCounter();
        }
    }
    
}
