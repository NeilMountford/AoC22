namespace AoC22.Solutions.Day5;

public class CrateUnloader9000 : CrateUnloader
{
    public CrateUnloader9000(string input) : base(input)
    {
    }

    public override string GetFinalTopOfStacks()
    {
        foreach (var move in Moves)
        {
            for (var i = 0; i < move.CratesToMove; i++)
            {
                var crate = Stacks[move.From - 1].Pop();
                Stacks[move.To - 1].Push(crate);
            }
        }

        return string.Join("", Stacks.Select(s => s.Peek()));
    }
}