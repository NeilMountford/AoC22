namespace AoC22.Solutions.Day10;

public class Cpu
{
    public List<int> XValues { get; }
    public int X { get; private set; }
    public Crt Crt { get; }

    public Cpu()
    {
        X = 1;
        XValues = new List<int> { 1 };
        Crt = new Crt();
    }

    public void ProcessInstruction(Instruction instruction)
    {
        for (var i = 0; i < instruction.Cycles - 1; i++)
        {
            XValues.Add(X);
            Crt.RenderFrame(this);
        }

        Crt.RenderFrame(this);
        X += instruction.Argument;
        XValues.Add(X);
    }
}