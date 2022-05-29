using System;
using Codecool.LifeOfAnts;

public abstract class Ant
{
    public Position Position;

    protected int _width;

    protected Ant(Position position, int width)
    {
        Position = position;
        _width = width;
    }

    public abstract void Act();

    protected int GetRandomDirection()
    {
        return new Random().Next((int)Direction.North, (int)Direction.West + 1);
    }

    protected void NextMove(int direction)
    {
        var queenPosition = _width / 2;
        switch (direction)
        {
            case (int)Direction.North:
            {
                if (Position.X > 0 && !(Position.X == queenPosition + 1 && Position.Y == queenPosition))
                {
                    Position.X -= 1;
                }

                break;
            }
            case (int)Direction.East:
            {
                if (Position.Y < _width - 1 && !(Position.Y == queenPosition - 1 && Position.X == queenPosition))
                {
                    Position.Y += 1;
                }

                break;
            }
            case (int)Direction.South:
            {
                if (Position.X < _width - 1 && !(Position.X == queenPosition - 1 && Position.Y == queenPosition))
                {
                    Position.X += 1;
                }

                break;
            }
            case (int)Direction.West:
            {
                if (Position.Y > 0 && !(Position.Y == queenPosition + 1 && Position.X == queenPosition))
                {
                    Position.Y -= 1;
                }

                break;
            }
        }
    }
}