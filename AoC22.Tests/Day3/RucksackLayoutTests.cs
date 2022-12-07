using AoC22.Solutions;
using AoC22.Solutions.Day3;

namespace AoC22.Tests.Day3;

public class RucksackLayoutTests
{
    [Fact]
    public void SumOfPrioritiesIsCorrect()
    {
        var input =
            "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw\n";

        var rucksackLayout = new RucksackLayout(input);
        var result = rucksackLayout.GetSumOfIncorrectlyPackedItemPriorities();

        result.Should().Be(157);
    }
}