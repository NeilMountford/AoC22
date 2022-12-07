using AoC22.Solutions.Day4;

namespace AoC22.Tests.Day4;

public class CleanupPartialCrossoverTests
{
    [Fact]
    public void CrossoverCorrectlyCalculated()
    {
        var input = "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8";

        var crossover = new CleanupCrossover(input);
        var result = crossover.GetPairsWithPartialOverlap();

        result.Should().Be(4);
    }
}