using FluentAssertions;
using Xunit;

namespace AoC22.Day2.Tests;

public class StrategyCalculatorTests
{
    [Fact]
    public void ScoreBasedOnStrategyIsCorrect()
    {
        var input = "A Y\nB X\nC Z";

        var calculator = new RockPaperScissorsStrategyCalculator(input);
        
        var result = calculator.CalculateScore();
        result.Should().Be(15);
    }
}