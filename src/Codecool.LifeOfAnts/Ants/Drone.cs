using System;

namespace Codecool.LifeOfAnts.Ants;

internal class Drone : Ant
{
    public int RestRemainingTime;

    public Drone(Position position, int width) : base(position, width)
    {
        RestRemainingTime = 0;
    }

    private void SetRestTime()
    {
        if (RestRemainingTime > 0)
        {
            RestRemainingTime--;
        }
    }

    public void Mating()
    {
        HappyDrone();
        RestRemainingTime = 10;
    }

    public override void Act()
    {
        SetRestTime();

        var queenPosition = _width / 2;

        int direction;
        var verticalDistance = Math.Abs(queenPosition - Position.X);
        var horizontalDistance = Math.Abs(queenPosition - Position.Y);
        if (verticalDistance > horizontalDistance)
        {
            direction = Position.X > queenPosition ? (int)Direction.North : (int)Direction.South;
        }
        else
        {
            direction = Position.Y > queenPosition ? (int)Direction.West : (int)Direction.East;
        }

        if (RestRemainingTime == 0)
        {
            NextMove(direction);
        }
    }

    public void DisappointedDrone()
    {
        Console.WriteLine(":(");
    }

    private void HappyDrone()
    {
        Console.WriteLine("HALLELUJAH");
    }
}