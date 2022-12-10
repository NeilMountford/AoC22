namespace AoC22.Solutions.Day10;

public class AddXInstruction : Instruction
{
    public override int Cycles => 2;
    public override int Argument { get; }

    public AddXInstruction(int argument)
    {
        Argument = argument;
    }
}