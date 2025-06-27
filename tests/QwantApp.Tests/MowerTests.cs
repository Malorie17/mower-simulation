using Moq;

namespace QwantApp.Tests;

public class MowerTests
{
    [Test]
    public async Task Mower_ShouldRotateCorrectly_WithoutMoving()
    {
        var mockLawn = new Mock<ILawn>();
        mockLawn.Setup(l => l.PlaceMower(It.IsAny<Point>()));

        var mower = new Mower(1, 0, 0, Orientation.N, "LRR", mockLawn.Object);

        await mower.Execute();

        Assert.That(mower.CurrentPosition, Is.EqualTo(new Point(0, 0)));
        Assert.That(mower.Orientation, Is.EqualTo(Orientation.E));
    }

    [Test]
    public async Task Mower_ShouldMoveForward_WhenPossible()
    {
        var mockLawn = new Mock<ILawn>();
        mockLawn.Setup(l => l.PlaceMower(It.IsAny<Point>()));
        mockLawn.Setup(l => l.TryMove(It.IsAny<Point>(), It.IsAny<Point>()))
                .Returns(true);

        var mower = new Mower(1, 0, 0, Orientation.N, "F", mockLawn.Object);

        await mower.Execute();

        Assert.That(mower.CurrentPosition, Is.EqualTo(new Point(0, 1)));
        Assert.That(mower.Orientation, Is.EqualTo(Orientation.N));
    }

    [Test]
    public async Task Mower_ShouldNotMoveForward_WhenBlockedByLawn()
    {
        var mockLawn = new Mock<ILawn>();
        mockLawn.Setup(l => l.PlaceMower(It.IsAny<Point>()));
        mockLawn.Setup(l => l.TryMove(It.IsAny<Point>(), It.IsAny<Point>()))
                .Returns(false);

        var mower = new Mower(1, 0, 0, Orientation.N, "F", mockLawn.Object);

        await mower.Execute();

        Assert.That(mower.CurrentPosition, Is.EqualTo(new Point(0, 0)));
        Assert.That(mower.Orientation, Is.EqualTo(Orientation.N));
    }
}
