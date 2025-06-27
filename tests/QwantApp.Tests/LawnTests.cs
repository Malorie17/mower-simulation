namespace QwantApp.Tests;

public class LawnTests
{
    private Lawn _lawn;

    [SetUp]
    public void Setup()
    {
        _lawn = new Lawn(5, 5);
    }

    [Test]
    public void PlaceMower_ShouldThrowException_WhenPlaceAlreadyOccupied()
    {
        var initialPos = new Point(1, 1);
        _lawn.PlaceMower(initialPos);

        Assert.Throws<InvalidOperationException>(() => _lawn.PlaceMower(initialPos));
    }

    [Test]
    public void PlaceMower_ShouldThrowException_WhenOutOfBounds()
    {
        var initialPos = new Point(6, 6);

        Assert.Throws<ArgumentOutOfRangeException>(() => _lawn.PlaceMower(initialPos));
    }

    [Test]
    public void TryMove_ShouldNotMoveMower_WhenOutOfBounds()
    {
        var currentPos = new Point(5, 5);
        var targetPos = new Point(5, 6);
        _lawn.PlaceMower(currentPos);
        var result = _lawn.TryMove(currentPos, targetPos);

        Assert.That(result, Is.False);
    }

    [Test]
    public void TryMove_ShouldNotMoveMower_WhenTargetPositionOccupied()
    {
        var mower1Pos = new Point(1, 1);
        var mower1TargetPos = new Point(1, 2);
        var mower2Pos = new Point(1, 2);
        _lawn.PlaceMower(mower1Pos);
        _lawn.PlaceMower(mower2Pos);
        var result = _lawn.TryMove(mower1Pos, mower1TargetPos);

        Assert.That(result, Is.False);
    }

    [Test]
    public void TryMove_ShouldMoveMower_WhenPositionFreeAndInBounds()
    {
        var currentPos = new Point(1, 1);
        var targetPos = new Point(1, 2);
        _lawn.PlaceMower(currentPos);
        var result = _lawn.TryMove(currentPos, targetPos);

        Assert.That(result, Is.True);
    }
}
