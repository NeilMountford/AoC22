namespace AoC22.Solutions.Day9;

public class HeadEnd : RopeEnd
{
    public void Move(Direction direction)
    {
        CurrentLocation = direction switch
        {
            Direction.Up => CurrentLocation with { Y = CurrentLocation.Y + 1 },
            Direction.Down => CurrentLocation with { Y = CurrentLocation.Y - 1 },
            Direction.Left => CurrentLocation with { X = CurrentLocation.X - 1 },
            Direction.Right => CurrentLocation with { X = CurrentLocation.X + 1 },
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}