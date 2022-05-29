namespace Codecool.LifeOfAnts.Ants;
internal class Worker : Ant
{
    public Worker(Position position, int width) : base(position, width)
    {

    }

    public override void Act()
    {
        var direction = GetRandomDirection();
        NextMove(direction);
    }
}