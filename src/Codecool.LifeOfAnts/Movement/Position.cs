namespace Codecool.LifeOfAnts;
/// <summary>
///     Position struct
/// </summary>
public struct Position
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Position"/> struct.
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    ///     Gets and Sets X coordinate
    /// </summary>
    public int X { get; set; }

    /// <summary>
    ///     Gets and Sets Y coordinate
    /// </summary>
    public int Y { get; set; }
}