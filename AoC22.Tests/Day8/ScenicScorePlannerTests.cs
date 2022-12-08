using AoC22.Solutions.Day8;

namespace AoC22.Tests.Day8;

public class ScenicScorePlannerTests
{
    [Fact]
    public void HighestScenicScoreIsReturned()
    {
        var input = "30373\n25512\n65332\n33549\n35390\n";

        var planner = new TreeHouseLocationPlanner(input);
        var result = planner.GetHighestScenicScore();

        result.Should().Be(8);
    }

}