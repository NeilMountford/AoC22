namespace AoC22.Solutions.Day5;

public abstract class CrateUnloader
{
    protected readonly Stack<string>[] Stacks;
    protected readonly int StackCount;
    protected readonly Move[] Moves;

    public CrateUnloader(string input)
    {
        var lines = input.Split("\n").ToList();
        var stackMoveSplit = lines.FindIndex(string.IsNullOrWhiteSpace);
        var stackNumberIndex = stackMoveSplit - 1;
        var moveIndex = stackMoveSplit + 1;
        StackCount = int.Parse(lines[stackNumberIndex].Trim().Last().ToString());
        
        Stacks = InitialiseStacks(StackCount);
        PopulateInitialStacks(lines.Take(stackNumberIndex).ToArray());
        Moves = ParseMoves(lines.Skip(moveIndex).ToArray());
    }

    private void PopulateInitialStacks(string[] lines)
    {
        for (var l = lines.Length - 1; l >= 0; l--)
        {
            var characters = lines[l].ToCharArray();
            for (var stack = 1; stack <= StackCount; stack++)
            {
                var crateColumn = ((stack - 1) * 4) + 1;
                var crate = characters[crateColumn];
                if (char.IsLetter(crate))
                {
                    Stacks[stack - 1].Push(crate.ToString());
                }
            }
        }
    }

    private Stack<string>[] InitialiseStacks(int stackCount)
    {
        var stacks = new Stack<string>[stackCount];
        for (var i = 0; i < stackCount; i++)
        {
            stacks[i] = new Stack<string>();
        }

        return stacks;
    }

    private Move[] ParseMoves(string[] moveLines)
    {
        return moveLines
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l =>
                    l.Trim()
                    .Split(new[] { "move", "from", "to" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray())
            .Select(splitLine => new Move(splitLine[0], splitLine[1], splitLine[2]))
            .ToArray();
    }

    public abstract string GetFinalTopOfStacks();
}