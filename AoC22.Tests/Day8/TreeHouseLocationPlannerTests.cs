using AoC22.Solutions.Day8;

namespace AoC22.Tests.Day8;

public class TreeHouseLocationPlannerTests
{
    [Fact]
    public void VisibleTreesAreCorrectlyCounted()
    {
        var input = "30373\n25512\n65332\n33549\n35390";

        var planner = new TreeHouseLocationPlanner(input);
        var result = planner.CountTreesVisibleFromOutside();

        result.Should().Be(21);
    }
    
    [Fact]
    public void VisibleTreesAreCorrectlyCountedWithTrailingNewline()
    {
        var input = "30373\n25512\n65332\n33549\n35390\n";

        var planner = new TreeHouseLocationPlanner(input);
        var result = planner.CountTreesVisibleFromOutside();

        result.Should().Be(21);
    }
}