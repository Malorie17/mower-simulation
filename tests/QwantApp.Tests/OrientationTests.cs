namespace QwantApp.Tests;

public class OrientationTests
{
    [Test]
    public void TurnLeft_ShouldRotateCorrectly()
    {
        Assert.That(Orientation.N.TurnLeft(), Is.EqualTo(Orientation.W));
        Assert.That(Orientation.E.TurnLeft(), Is.EqualTo(Orientation.N));
        Assert.That(Orientation.S.TurnLeft(), Is.EqualTo(Orientation.E));
        Assert.That(Orientation.W.TurnLeft(), Is.EqualTo(Orientation.S));
    }

    [Test]
    public void TurnRight_ShouldRotateCorrectly()
    {
        Assert.That(Orientation.N.TurnRight(), Is.EqualTo(Orientation.E));
        Assert.That(Orientation.E.TurnRight(), Is.EqualTo(Orientation.S));
        Assert.That(Orientation.S.TurnRight(), Is.EqualTo(Orientation.W));
        Assert.That(Orientation.W.TurnRight(), Is.EqualTo(Orientation.N));
    }
}