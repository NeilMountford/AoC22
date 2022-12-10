namespace AoC22.Solutions.Day10;

public class NoopInstruction : Instruction
{
    public override int Cycles => 1;
    public override int Argument => 0;
}