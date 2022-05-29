using System;

namespace Codecool.LifeOfAnts.Ants;
internal class Queen : Ant
{
    private int _moodChance;

    public bool IsMood;

    public Queen(Position position, int width) : base(position, width)
    {
        SetMood();
    }

    public override void Act()
    {
        _moodChance--;
        if (_moodChance == 0)
        {
            IsMood = true;
        }
    }

    public void KickOff(Drone drone)
    {
        drone.DisappointedDrone();
        var direction = GetRandomDirection();
        switch (direction)
        {
            case (int)Direction.North:
                drone.Position.X = _width - _width;
                break;
            case (int)Direction.East:
                drone.Position.Y = _width - 1;
                break;
            case (int)Direction.South:
                drone.Position.X = _width - 1;
                break;
            case (int)Direction.West:
                drone.Position.Y = _width - _width;
                break;
        }
    }

    public void SetMood()
    {
        _moodChance = new Random().Next(50, 101);
        IsMood = false;
    }
}