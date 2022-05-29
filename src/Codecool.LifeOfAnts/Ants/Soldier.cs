namespace Codecool.LifeOfAnts.Ants;
internal class Soldier : Ant
{
    private int _direction;

    public Soldier(Position position, int width) : base(position, width)
    {
        _direction = (int)Direction.East;
    }

    public override void Act()
    {
        if (_direction == 0)
        {
            _direction = (int)Direction.West;
        }
        else
        {
            _direction--;
        }

        NextMove(_direction);
    }
}