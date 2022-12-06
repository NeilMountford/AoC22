using FluentAssertions;
using Xunit;

namespace AoC22.Day2.Tests;

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