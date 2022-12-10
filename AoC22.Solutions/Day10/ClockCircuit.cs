namespace AoC22.Solutions.Day10;

public class ClockCircuit
{
    private readonly Instruction[] _instructions;
    private readonly Cpu _cpu;

    public ClockCircuit(string input)
    {
        _instructions = input
            .Split("\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(
                l =>
                {
                    if (l == "noop")
                    {
                        return (Instruction) new NoopInstruction();
                    }

                    var commandSplit = l.Split(" ");
                    if (commandSplit[0] == "addx")
                    {
                        return new AddXInstruction(int.Parse(commandSplit[1]));
                    }

                    throw new ArgumentOutOfRangeException();
                })
            .ToArray();

        _cpu = new Cpu();
    }

    public int GetSignalStrength()
    {
        foreach (var instruction in _instructions)
        {
            _cpu.ProcessInstruction(instruction);
        }

        var signalStrengthCycles = new[] { 20, 60, 100, 140, 180, 220 };

        return signalStrengthCycles.Select(i => _cpu.XValues[i - 1] * i).Sum();
    }

    public IEnumerable<string> GetCrtImage()
    {
        foreach (var instruction in _instructions)
        {
            _cpu.ProcessInstruction(instruction);
        }
        
        return _cpu.Crt.GetDisplayOutput();
    }
}