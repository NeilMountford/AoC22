using System;
using AoC22.Solutions.Day1;

namespace AoC22.Tests.Day1;

public class MostCalorieTests
{
    [Fact]
    public void ElfWithMostCaloriesIsUsed()
    {
        var input = @"1000

2000

1500
";

        var calculator = new ElfCalorieCalculator(input, Environment.NewLine);
        var result = calculator.GetCaloriesForElfWithHighest();
        result.Should().Be(2000);
    }
    
    [Fact]
    public void ElfWithMostCaloriesIsUsedMultiple()
    {
        var input = @"1000
2000
3000

2000
5000

1500
1000
";

        var calculator = new ElfCalorieCalculator(input, Environment.NewLine);
        var result = calculator.GetCaloriesForElfWithHighest();
        result.Should().Be(7000);
    }
    
    [Fact]
    public void ElvesWithNothingAreIgnored()
    {
        var input = @"1000
2000
3000


2000
5000

1500
1000
";

        var calculator = new ElfCalorieCalculator(input, Environment.NewLine);
        var result = calculator.GetCaloriesForElfWithHighest();
        result.Should().Be(7000);
    }
    
    [Fact]
    public void NewlineCharactersFromOtherEnvsSupported()
    {
        var input = "1000\n2000\n\n3000\n\n\n2000\n5000\n\n1500\n1000";

        var calculator = new ElfCalorieCalculator(input, "\n");
        var result = calculator.GetCaloriesForElfWithHighest();
        result.Should().Be(7000);
    }
}