namespace QwantApp;

public class Lawn : ILawn
{
    private readonly int _maxX;
    private readonly int _maxY;
    private readonly HashSet<Point> _occupiedPositions;
    private readonly object _lock = new();

    public Lawn(int maxX, int maxY)
    {
        _maxX = maxX;
        _maxY = maxY;
        _occupiedPositions = new HashSet<Point>();
    }

    private bool IsWithinBounds(Point p)
    {
        return p.X >= 0 && p.X <= _maxX && p.Y >= 0 && p.Y <= _maxY;
    }

    public void PlaceMower(Point initialPos)
    {
        lock (_lock)
        {
            if (!IsWithinBounds(initialPos))
            {
                throw new ArgumentOutOfRangeException($"Initial position {initialPos} is out of lawn bounds ({_maxX},{_maxY}).");
            }
            if (!_occupiedPositions.Add(initialPos))
            {
                throw new InvalidOperationException($"Initial position {initialPos} is already occupied by another mower.");
            }
        }
    }

    public bool TryMove(Point currentPos, Point targetPos)
    {
        lock (_lock)
        {
            if (!IsWithinBounds(targetPos))
            {
                return false;
            }

            if (_occupiedPositions.Contains(targetPos) && !targetPos.Equals(currentPos))
            {
                return false;
            }

            _occupiedPositions.Remove(currentPos);
            _occupiedPositions.Add(targetPos);

            return true;
        }
    }
}
