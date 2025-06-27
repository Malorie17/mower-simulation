namespace QwantApp;
public class Mower
{
    private readonly int _id;
    private Point _currentPosition;
    private Orientation _orientation;
    private readonly string _instructions;
    private readonly ILawn _lawn;

    public Mower(int id, int startX, int startY, Orientation startOrientation, string instructions, ILawn lawn)
    {
        _id = id;
        _currentPosition = new Point(startX, startY);
        _orientation = startOrientation;
        _instructions = instructions;
        _lawn = lawn;

        _lawn.PlaceMower(_currentPosition);
    }

    public async Task Execute()
    {
        await Task.Run(() =>
        {
            foreach (var instruction in _instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        _orientation = _orientation.TurnLeft();
                        break;
                    case 'R':
                        _orientation = _orientation.TurnRight();
                        break;
                    case 'F':
                        var nextPosition = CalculateNextPosition();
                        if (_lawn.TryMove(_currentPosition, nextPosition))
                        {
                            _currentPosition = nextPosition;
                        }
                        break;
                }
            }
        });
    }

    private Point CalculateNextPosition()
    {
        var nextX = _currentPosition.X;
        var nextY = _currentPosition.Y;

        switch (_orientation)
        {
            case Orientation.N: nextY++; break;
            case Orientation.E: nextX++; break;
            case Orientation.S: nextY--; break;
            case Orientation.W: nextX--; break;
        }

        return new Point(nextX, nextY);
    }

    public Point CurrentPosition => _currentPosition;
    public Orientation Orientation => _orientation;

    public override string ToString()
    {
        return $"{_currentPosition.X} {_currentPosition.Y} {_orientation}";
    }
}
