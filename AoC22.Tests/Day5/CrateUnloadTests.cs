using AoC22.Solutions.Day5;

namespace AoC22.Tests.Day5;

public class CrateUnloadTests
{
    [Fact]
    public void FinalCratePositionIsCorrectForModel9000()
    {
        var input =
            "    [D]    \n[N] [C]    \n[Z] [M] [P]\n 1   2   3 \n\nmove 1 from 2 to 1\nmove 3 from 1 to 3\nmove 2 from 2 to 1\nmove 1 from 1 to 2";

        var unloader = new CrateUnloader9000(input);
        var finalPosition = unloader.GetFinalTopOfStacks();

        finalPosition.Should().Be("CMZ");
    }
    
    [Fact]
    public void FinalCratePositionIsCorrectForModel9001()
    {
        var input =
            "    [D]    \n[N] [C]    \n[Z] [M] [P]\n 1   2   3 \n\nmove 1 from 2 to 1\nmove 3 from 1 to 3\nmove 2 from 2 to 1\nmove 1 from 1 to 2";

        var unloader = new CrateUnloader9001(input);
        var finalPosition = unloader.GetFinalTopOfStacks();

        finalPosition.Should().Be("MCD");
    }
}