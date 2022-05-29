using System;

namespace Codecool.LifeOfAnts;
/// <summary>
///     Simulation main class
/// </summary>
public static class Program
{
    /// <summary>
    ///     Main method
    /// </summary>
    public static void Main()
    {
        var colony = new AntColony(11);
        CreateColony(colony);
        ColonyLife(colony);
    }

    private static void CreateColony(AntColony colony)
    {
        colony.GenerateAnts(4, 2, 2);
        colony.Display();
    }

    private static void ColonyLife(AntColony colony)
    {
        while (Input())
        {
            Console.Clear();
            colony.Update();
            colony.Display();
        }
        Console.Clear();
        Console.WriteLine("Bye bye");
    }

    private static bool Input()
    {
        var input = Console.ReadLine();
        return input switch
        {
            "q" => false,
            _ => true
        };
    }
}