namespace AoC22.Solutions.Day5;

public class CrateUnloader9001 : CrateUnloader
{
    public CrateUnloader9001(string input) : base(input)
    {
    }

    public override string GetFinalTopOfStacks()
    {
        foreach (var move in Moves)
        {
            var temporaryStack = new Stack<string>();
            for (var i = 0; i < move.CratesToMove; i++)
            {
                temporaryStack.Push(Stacks[move.From - 1].Pop());
            }

            foreach (var crate in temporaryStack)
            {
                Stacks[move.To - 1].Push(crate);
            }
        }

        return string.Join("", Stacks.Select(s => s.Peek()));
    }
}