using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Command leftCommand;
    [SerializeField] private Command rightCommand;
    [SerializeField] private Command rotateLeftCommand;
    [SerializeField] private Command rotateRightCommand;
    [SerializeField] private Command fastDropCommand;

    private void OnGameObjectInstantiated()
    {
        leftCommand = FindObjectOfType<LeftCommand>();
        rightCommand = FindObjectOfType<RightCommand>();
        rotateLeftCommand = FindObjectOfType<RotateLeftCommand>();
        rotateRightCommand = FindObjectOfType<RotateRightCommand>();
        fastDropCommand = FindObjectOfType<FastDropCommand>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            leftCommand?.Execute();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rightCommand?.Execute();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotateLeftCommand?.Execute();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotateRightCommand?.Execute();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            fastDropCommand?.Execute();
        }
    }
}