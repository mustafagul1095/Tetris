using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRightCommand : Command
{
    private Shape1ChildRotater _shape1Mover;

    private void Awake()
    {
        _shape1Mover = GetComponent<Shape1ChildRotater>();
    }

    public override void Execute()
    {
        _shape1Mover.RotateRight();
    }
}
