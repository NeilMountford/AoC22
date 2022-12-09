namespace AoC22.Solutions.Day9;

public class TailEnd : RopeEnd
{
    public HashSet<Coordinate> VisitedCoordinates { get; }

    public TailEnd()
    {
        VisitedCoordinates = new HashSet<Coordinate>
        {
            CurrentLocation
        };
    }

    public void Move(RopeEnd previousKnot)
    {
        // Rope is not on same row or column, needs to move diagonally
        var xMove = 0;
        var yMove = 0;

        if (previousKnot.CurrentLocation.Y > CurrentLocation.Y + 1)
        {
            yMove = 1;
        }
        else if (previousKnot.CurrentLocation.Y < CurrentLocation.Y - 1)
        {
            yMove = -1;
        }

        if (previousKnot.CurrentLocation.X > CurrentLocation.X + 1)
        {
            xMove = 1;
        }
        else if (previousKnot.CurrentLocation.X < CurrentLocation.X - 1)
        {
            xMove = -1;
        }

        if (yMove != 0)
        {
            if (previousKnot.CurrentLocation.X > CurrentLocation.X)
            {
                xMove = 1;
            }
            else if (previousKnot.CurrentLocation.X < CurrentLocation.X)
            {
                xMove = -1;
            }
        }

        if (xMove != 0)
        {
            if (previousKnot.CurrentLocation.Y > CurrentLocation.Y)
            {
                yMove = 1;
            }
            else if (previousKnot.CurrentLocation.Y < CurrentLocation.Y)
            {
                yMove = -1;
            }
        }
        

        CurrentLocation = new Coordinate(CurrentLocation.X + xMove, CurrentLocation.Y + yMove);
        
        VisitedCoordinates.Add(CurrentLocation);
    }
}