using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public Direction Direction { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }

    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    public void Move(string instructions)
    {
        foreach (char command in instructions)
        {
            switch (command)
            {
                case 'R': TurnRight(); break;
                case 'L': TurnLeft(); break;
                case 'A': Advance(); break;
            }
        }
    }

    private void TurnRight()
    {
        // Cycles: North (0) -> East (1) -> South (2) -> West (3) -> North (0)
        Direction = (Direction == Direction.West) ? Direction.North : Direction + 1;
    }

    private void TurnLeft()
    {
        // Cycles: North (0) -> West (3) -> South (2) -> East (1) -> North (0)
        Direction = (Direction == Direction.North) ? Direction.West : Direction - 1;
    }

    private void Advance()
    {
        switch (Direction)
        {
            case Direction.North: Y++; break;
            case Direction.East:  X++; break;
            case Direction.South: Y--; break;
            case Direction.West:  X--; break;
        }
    }
}