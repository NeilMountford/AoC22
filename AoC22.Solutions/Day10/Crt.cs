using System.Text;

namespace AoC22.Solutions.Day10;

public class Crt
{
    private readonly StringBuilder _output;

    public Crt()
    {
        _output = new StringBuilder();
    }

    public void RenderFrame(Cpu cpu)
    {
        var currentPosition = _output.Length % 40;
        if (cpu.X >= currentPosition - 1 && cpu.X <= currentPosition + 1)
        {
            _output.Append('#');
        }
        else
        {
            _output.Append('.');
        }
    }

    public IEnumerable<string> GetDisplayOutput()
    {
        var finalOutput = _output.ToString();
        var chunkSize = 40;
        return Enumerable.Range(0, finalOutput.Length / chunkSize)
            .Select(i => finalOutput.Substring(i * chunkSize, chunkSize));
    }
}