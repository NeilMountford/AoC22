using AoC22.Solutions.Day2;

namespace AoC22.Tests.Day2;

public class HandShapeOutcomeStrategyTests
{
    [Fact]
    public void ScoreBasedOnStrategyIsCorrect()
    {
        var input = "A Y\nB X\nC Z";

        var calculator = new HandShapeOutcomeStrategyCalculator(input);
        
        var result = calculator.CalculateScore();
        result.Should().Be(12);
    }
}