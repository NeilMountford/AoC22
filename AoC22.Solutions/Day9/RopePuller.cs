namespace AoC22.Solutions.Day9;

public class RopePuller
{
    private readonly List<HeadCommand> _commands;

    public RopePuller(string input)
    {
        var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        _commands = lines.Select(l =>
            {
                var split = l.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var direction = split[0] switch
                {
                    "U" => Direction.Up,
                    "D" => Direction.Down,
                    "L" => Direction.Left,
                    "R" => Direction.Right,
                    _ => throw new ArgumentOutOfRangeException()
                };
                var amount = int.Parse(split[1]);
                return new HeadCommand(direction, amount);
            })
            .ToList();
    }

    public int CountTailLocationsVisited(int tailKnotCount)
    {
        var head = new HeadEnd();
        var tailKnots = Enumerable.Range(0, tailKnotCount)
            .Select(_ => new TailEnd())
            .ToArray();

        foreach (var command in _commands)
        {
            for (var i = 0; i < command.Amount; i++)
            {
                head.Move(command.Direction);
                tailKnots[0].Move(head);
                for (var tailKnot = 1; tailKnot < tailKnotCount; tailKnot++)
                {
                    tailKnots[tailKnot].Move(tailKnots[tailKnot-1]);
                }
            }
        }

        return tailKnots.Last().VisitedCoordinates.Count;
    }
}