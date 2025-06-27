namespace QwantApp;

public enum Orientation { N, E, S, W }

public static class OrientationHelper
{
    public static Orientation TurnLeft(this Orientation current)
    {
        return current switch
        {
            Orientation.N => Orientation.W,
            Orientation.E => Orientation.N,
            Orientation.S => Orientation.E,
            Orientation.W => Orientation.S,
            _ => throw new ArgumentOutOfRangeException(nameof(current), current, null)
        };
    }

    public static Orientation TurnRight(this Orientation current)
    {
        return current switch
        {
            Orientation.N => Orientation.E,
            Orientation.E => Orientation.S,
            Orientation.S => Orientation.W,
            Orientation.W => Orientation.N,
            _ => throw new ArgumentOutOfRangeException(nameof(current), current, null)
        };
    }
}
