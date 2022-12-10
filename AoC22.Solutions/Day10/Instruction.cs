namespace AoC22.Solutions.Day10;

public abstract class Instruction
{
    public virtual int Cycles { get; }
    public virtual int Argument { get; }
}