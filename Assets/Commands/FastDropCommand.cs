using System;

public class FastDropCommand : Command
{
    private Shape1Mover _shape1Mover;

    private void Awake()
    {
        _shape1Mover = GetComponent<Shape1Mover>();
    }

    public override void Execute()
    {
        _shape1Mover.FastDrop();
    }
}