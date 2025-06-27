namespace QwantApp;

public interface ILawn
{
    void PlaceMower(Point initialPos);
    bool TryMove(Point currentPos, Point targetPos);
}
