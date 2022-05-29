using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.LifeOfAnts.Ants;

namespace Codecool.LifeOfAnts;

public class AntColony
{
    private readonly int _width;

    private readonly List<Ant> _ants;

    public AntColony(int width)
    {
        _width = width;
        var queen = new Queen(new Position(width / 2, width / 2), _width);
        _ants = new List<Ant> { queen };
    }

    public void GenerateAnts(int drones, int workers, int soldiers)
    {
        GenerateAnt("D", drones);
        GenerateAnt("W", workers);
        GenerateAnt("S", soldiers);
    }

    private void GenerateAnt(string symbol, int count)
    {
        for (var i = 0; i < count; i++)
        {
            switch (symbol)
            {
                case "D":
                    {
                        var (x, y) = RandomPlace();
                        _ants.Insert(0, new Drone(new Position(x, y), _width));
                        break;
                    }
                case "W":
                    {
                        var (x, y) = RandomPlace();
                        _ants.Insert(0, new Worker(new Position(x, y), _width));
                        break;
                    }
                case "S":
                    {
                        var (x, y) = RandomPlace();
                        _ants.Insert(0, new Soldier(new Position(x, y), _width));
                        break;
                    }
            }
        }
    }

    private (int x, int y) RandomPlace()
    {
        var random = new Random();
        var x = random.Next(0, _width);
        var y = random.Next(0, _width);
        return (x, y);
    }

    public void Update()
    {
        foreach (var ant in _ants)
        {
            ant.Act();
        }
        CheckDronePosition();
    }

    private void CheckDronePosition()
    {
        var queenPosition = _width / 2;
        foreach (var ant in _ants)
        {
            if (ant is not Drone drone) continue;

            if ((ant.Position.X > queenPosition + 1 || ant.Position.X < queenPosition - 1) ||
                (ant.Position.Y > queenPosition + 1 || ant.Position.Y < queenPosition - 1)) continue;

            if (_ants[^1] is not Queen queen) continue;

            if (queen.IsMood)
            {
                drone.Mating();
                queen.SetMood();
            }
            else
            {
                if (drone.RestRemainingTime == 0)
                {
                    queen.KickOff(drone);
                }
            }
        }
    }

    public void Display()
    {
        var colony = "";

        for (var i = 0; i < _width; i++)
        {
            for (var j = 0; j < _width; j++)
            {
                colony += $"{CheckForAnt(i, j)} ";
            }

            colony += "\n";
        }

        Console.WriteLine(colony);
    }

    private string CheckForAnt(int x, int y)
    {
        return _ants.Where(ant => ant.Position.X == x && ant.Position.Y == y)
            .Aggregate("-", (current, ant) => ant switch
            {
                Drone => "D",
                Worker => "W",
                Soldier => "S",
                Queen => "Q",
                _ => current
            });
    }
}