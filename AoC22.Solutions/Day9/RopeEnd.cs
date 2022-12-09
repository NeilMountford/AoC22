namespace AoC22.Solutions.Day9;

public abstract class RopeEnd
{
    public Coordinate CurrentLocation { get; set; }

    public RopeEnd()
    {
        CurrentLocation = new Coordinate(0, 0);
    }
}